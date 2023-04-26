using LoansNF.Domain.Applications;
using NUnit.Framework.Constraints;

namespace Loans.Tests
{
    public class MonthlyRepaymentGreatherThanZeroConstraint : Constraint
    {
        public string ExpectedProductName { get; private set; }
        public decimal ExpectedInterestRate { get; private set; }

        public MonthlyRepaymentGreatherThanZeroConstraint(string expectedProductName,
            decimal expectedInterestRate)
        {
            ExpectedProductName = expectedProductName;
            ExpectedInterestRate = expectedInterestRate;
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            ConstraintResult result;
            MonthlyRepaymentComparison value = actual as MonthlyRepaymentComparison;
            if (value != null)
            {
                if (value.ProductName == ExpectedProductName
                    && value.InterestRate == ExpectedInterestRate
                    && value.MonthlyRepayment > 0)
                {
                    result = new ConstraintResult(this, actual, ConstraintStatus.Success);
                }
                else
                {
                    result = new ConstraintResult(this, actual, ConstraintStatus.Failure);
                }
            }
            else
            {
                result = new ConstraintResult(this, actual, ConstraintStatus.Error);
            }

            return result;
        }
    }
}
