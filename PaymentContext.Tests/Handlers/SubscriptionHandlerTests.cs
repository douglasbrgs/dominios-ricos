using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Peter";
            command.LastName = "Parker";
            command.Document = "99999999999";
            command.Email = "hello@balta.io2";
            command.BarCode = "1234567890";
            command.BoletoNumber = "1234567890";
            command.PaymentNumber = "1234567890";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Stark";
            command.PayerDocument = "1234567890";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "stark@industries.com";
            command.Street = "Rua Teste";
            command.Number = "1";
            command.Neighborhood = "Bairro Teste";
            command.City = "Cidade Teste";
            command.State = "Estado Teste";
            command.Country = "Pais Teste";
            command.ZipCode = "1234567890";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}
