﻿using PaymentContext.Domain.Services;

namespace PaymentContext.Tests.Mocks
{
    internal class FakeEmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
