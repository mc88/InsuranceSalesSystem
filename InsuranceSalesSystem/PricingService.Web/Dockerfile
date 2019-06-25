FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk  AS build
WORKDIR /src
COPY InsuranceSalesSystem/*.sln ./
COPY InsuranceSalesSystem/PricingService.Web/PricingService.Web.csproj PricingService.Web/
COPY InsuranceSalesSystem/PricingService.Bo/PricingService.Bo.csproj PricingService.Bo/
COPY InsuranceSalesSystem/PricingService.Api/PricingService.Api.csproj PricingService.Api/
#RUN dotnet restore 

COPY InsuranceSalesSystem/. .
WORKDIR /src/PricingService.Web
RUN dotnet build -c Release -o /app
#TODO: try to run ef migration here from cmd, now migrations are excuted from code
#RUN dotnet ef -p ../PricingService.Bo database update

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PricingService.Web.dll"]
