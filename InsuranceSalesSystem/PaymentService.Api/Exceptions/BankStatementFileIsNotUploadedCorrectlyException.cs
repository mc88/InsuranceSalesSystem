using System;

namespace PaymentService.Api.Exceptions
{
    public class BankStatementFileIsNotUploadedCorrectlyException : Exception
    {
        public override string Message
        {
            get
            {
                return $"Bank statement file is not uploaded correctly. File path is invalid.";
            }
        }
    }
}
