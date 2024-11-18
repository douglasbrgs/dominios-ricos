using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            Document document = new Document("123", Domain.Enums.EDocumentType.CNPJ);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            Document document = new Document("81412891000195", Domain.Enums.EDocumentType.CNPJ);
            Assert.IsTrue(document.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            Document document = new Document("123", Domain.Enums.EDocumentType.CPF);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("45781749055")]
        [DataRow("39836104046")]
        [DataRow("56961580050")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            Document document = new Document(cpf, Domain.Enums.EDocumentType.CPF);
            Assert.IsTrue(document.Valid);
        }
    }
}

