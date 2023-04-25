using LoansNF.Domain.Applications;
using NUnit.Framework;
using System.Collections.Generic;

namespace Loans.Tests
{
    [TestFixture]
    public class ProductComparerShould
    {
        [Test]
        public void ReturnCorrectNumberOfComparisons()
        {
            //Arrange Phase.
            var productos = new System.Collections.Generic.List<LoanProduct>
            {
                new LoanProduct(1, "a", 1),
                new LoanProduct(2, "b", 2),
                new LoanProduct(3, "c", 3)
            };
            var loanYears = 1;
            var numberOfProducts = productos.Count;
            var loan = new LoanAmount("MXN", 5000_000m);
            var productCompare_sut = new ProductComparer(loan, productos);
            var loanTerm = new LoanTerm(loanYears);

            //Act Phase.
            var monthlyRepaymentComparision = productCompare_sut.CompareMonthlyRepayments(loanTerm);

            //Assert Phase.
            Assert.That(monthlyRepaymentComparision, Has.Exactly(3).Items);
            //Equivalent.
            Assert.That(monthlyRepaymentComparision.Count, Is.EqualTo(numberOfProducts)); //Verificamos que el número de productos coincida con el número de comparación de productos respecto al pago mensual acorde al prestamo.
        }

        [Test]
        public void NotReturnCorrectNumberOfComparisons()
        {
            //Arrange Phase.
            var productos = new List<LoanProduct>
            {
                new LoanProduct(1, "a", 1),
                new LoanProduct(2, "b", 2),
                new LoanProduct(3, "c", 3)
            };
            var loanYears = 1;
            var loan = new LoanAmount("MXN", 5000_000m);
            var productCompare_sut = new ProductComparer(loan, productos);
            var loanTerm = new LoanTerm(loanYears);

            //Act Phase.
            List<MonthlyRepaymentComparison> monthlyRepaymentComparision = productCompare_sut.CompareMonthlyRepayments(loanTerm);

            //Assert Phase.
            Assert.That(monthlyRepaymentComparision, Is.Unique);
        }

        [Test]
        public void ReturnComparisonForFistProduct()
        {
            //Arrange Phase.
            var productos = new List<LoanProduct>
            {
                new LoanProduct(1, "a", 1),
                new LoanProduct(2, "b", 2),
                new LoanProduct(3, "c", 3)
            };
            var RespectFirtMonthlyRepaymentComparison = new MonthlyRepaymentComparison("a", 1, 643.28m);
            var loanYears = 30;
            var loan = new LoanAmount("MXN", 200_000m);
            var productCompare_sut = new ProductComparer(loan, productos);
            var loanTerm = new LoanTerm(loanYears);

            //Act Phase.
            List<MonthlyRepaymentComparison> monthlyRepaymentComparision = productCompare_sut.CompareMonthlyRepayments(loanTerm);

            //Assert Phase.
            Assert.That(monthlyRepaymentComparision, Does.Contain(RespectFirtMonthlyRepaymentComparison));
        }

        [Test]
        public void ReturnComparisonForFistProduct_WithPartialKnownExpectedValues()
        {
            //Arrange Phase.
            var productos = new List<LoanProduct>
            {
                new LoanProduct(1, "a", 1),
                new LoanProduct(2, "b", 2),
                new LoanProduct(3, "c", 3)
            };

            var loanYears = 30;
            var loan = new LoanAmount("MXN", 200_000m);
            var productCompare_sut = new ProductComparer(loan, productos);
            var loanTerm = new LoanTerm(loanYears);

            //Act Phase.
            List<MonthlyRepaymentComparison> monthlyRepaymentComparision = productCompare_sut.CompareMonthlyRepayments(loanTerm);

            //Assert Phase.
            Assert.That(monthlyRepaymentComparision, Has.Exactly(1)
                .Property("ProductName").EqualTo("a")
                .And
                .Property("InterestRate").EqualTo(1)
                .And
                .Property("MonthlyRepayment").GreaterThan(0m));

            //Equivalent.
            Assert.That(monthlyRepaymentComparision, Has.Exactly(1)
                .Matches<MonthlyRepaymentComparison>(item =>
                    item.ProductName.Equals("a") && item.InterestRate.Equals(1) && item.MonthlyRepayment >= 0m));
        }
    }
}