using LoansNF.Domain.Applications;
using NUnit.Framework;

namespace Loans.Tests
{
    public class MonthlyRepaymentComparisonShould
    {
        [Test]
        [Category("EqualityComparision")]
        public void ReturnEqualityMonthlyRepaymentComparison()
        {
            //Arrange Phase.
            var monthlyComparison1 = new MonthlyRepaymentComparison("a", 1.18m, 25.98m);
            var monthlyComparison2 = new MonthlyRepaymentComparison("a", 1.18m, 25.98m);

            //Act Phase.
            //No aplica.

            //Assert Phase.
            Assert.That(monthlyComparison1, Is.EqualTo(monthlyComparison2));
        }

        [Test]
        public void ReturnInequalityMonthlyRepaymentComparison()
        {
            //Arrange Phase.
            var monthlyComparison1 = new MonthlyRepaymentComparison("a", 1.18m, 25.98m);
            var monthlyComparison2 = new MonthlyRepaymentComparison("b", 1.18m, 25.98m);

            //Act Phase.
            //No aplica.

            //Assert Phase.
            Assert.That(monthlyComparison1, Is.Not.EqualTo(monthlyComparison2));
        }
    }
}
