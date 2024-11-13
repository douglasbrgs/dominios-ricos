using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarAssinaturaTest()
        {
            Subscription subscription = new Subscription(null);
            Name name = new Name("Douglas", "Borges");
            Document document = new Document("1234567890", Domain.Enums.EDocumentType.CPF);
            Email email = new Email("douglas@email.com");

            Student student = new Student(name, document, email);
            student.AddSubscription(subscription);

            foreach (var not in name.Notifications)
            {
                Console.WriteLine(not.Message);
            }
        }
    }
}
