using MediatR;
using PolicyService.Api.Dto.Requests;
using PolicyService.Api.Dto.Responses;
using PolicyService.Api.Exceptions;
using PolicyService.Bo.Infrastructure.Database;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PolicyService.Bo.Infrastructure.Communication.Events;
using PolicyService.Api.Dto.Events;
using PolicyService.Bo.Domain;
using Microsoft.Extensions.Logging;

namespace PolicyService.Bo.Handlers
{
    public class ConvertOfferHandler : IRequestHandler<ConvertOfferRequestDto, ConvertOfferResponseDto>
    {
        private readonly PolicyDbContext dbContext;
        private readonly IEventPublisher eventPublisher;
        private readonly ILogger<ConvertOfferHandler> logger;

        public ConvertOfferHandler(PolicyDbContext dbContext, IEventPublisher eventPublisher, ILogger<ConvertOfferHandler> logger)
        {
            this.dbContext = dbContext;
            this.eventPublisher = eventPublisher;
            this.logger = logger;
        }

        public Task<ConvertOfferResponseDto> Handle(ConvertOfferRequestDto request, CancellationToken cancellationToken)
        {
            //TODO: validate request

            var offer = dbContext.Offer.Include(x => x.Covers).Include(x => x.PolicyHolder).FirstOrDefault(x => x.OfferNumber == request.OfferNumber);

            if (offer == null)
            {
                logger.LogError($"Offer with number {request?.OfferNumber} not found");
                throw new OfferNotFoundException(request.OfferNumber);
            }

            logger.LogInformation($"Offer with number {request?.OfferNumber} found");

            //TODO: check offer is not expired and status
            //TODO: check if there is no policy created for this offer

            var policy = offer.ConvertToPolicy();
            dbContext.Policy.Add(policy);
            dbContext.SaveChanges();

            logger.LogInformation($"Offer with number {request?.OfferNumber} converted to policy: {policy.PolicyNumber}");

            PublishEvents(policy, offer);

            var response = new ConvertOfferResponseDto()
            {
                PolicyNumber = policy.PolicyNumber
            };

            return Task.FromResult(response);
        }

        private void PublishEvents(Policy policy, Offer offer)
        {
            var policyCreateEvent = new PolicyCreatedEvent()
            {
                PolicyNumber = policy.PolicyNumber,
                PolicyStartDate = offer.PolicyFrom,
                Price = offer.TotalPrice
            };

            eventPublisher.Publish(policyCreateEvent);

            logger.LogInformation($"PolicyCreatedEvent published, PolicyNumber: {policyCreateEvent.PolicyNumber}, PolicyFrom: {offer.PolicyFrom}, Price: {offer.TotalPrice}");
        }
    }
}
