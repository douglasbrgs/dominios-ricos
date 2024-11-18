using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System.Net;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Peter", "Parker");
            _document = new Document("31067482067", Domain.Enums.EDocumentType.CPF);
            _email = new Email("peter@parker.com");
            _address = new Address("Rua 1", "1234", "Bairro Legal", "Porto Alegre", "RS", "BR", "12333456");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            Payment payment = new PaypalPayment("1234567890", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "AVENGERS", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            Payment payment = new PaypalPayment("1234567890", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "AVENGERS", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}