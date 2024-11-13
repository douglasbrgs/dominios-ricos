using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarAssinaturaTest()
        {
            Subscription subscription = new Subscription(null);
            Student student = new Student("Douglas", "Borges", "1234567890", "douglas@email.com");
            student.AddSubscription(subscription);
        }
    }
}
