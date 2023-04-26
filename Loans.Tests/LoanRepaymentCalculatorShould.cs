using LoansNF.Domain.Applications;
using NUnit.Framework;

namespace Loans.Tests
{
    public class LoanRepaymentCalculatorShould
    {
        [Test]
        [TestCase(200_000, 6.5, 30, 1264.14)]
        [TestCase(200_000, 10, 30, 1755.14)]
        [TestCase(500_000, 10, 30, 4387.86)]
        public void CalculateCorrectMonthlyRepayment(
            decimal principal,
            decimal interestRate,
            int termInYears,
            decimal expectedMonthlyPayment)
        {
            //Arrange Phase.
            var sut = new LoanRepaymentCalculator();

            //Act Phase.
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("MXN", principal), interestRate, new LoanTerm(termInYears));

            //Assert Phase.
            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }

        [Test]
        [TestCase(200_000, 6.5, 30, ExpectedResult = 1264.14)]
        [TestCase(200_000, 10, 30, ExpectedResult = 1755.14)]
        [TestCase(500_000, 10, 30, ExpectedResult = 4387.86)]
        public decimal CalculateCorrectMonthlyRepayment_SimplifiedTestCase(
            decimal principal,
            decimal interestRate,
            int termInYears)
        {
            //Arrange Phase.
            var sut = new LoanRepaymentCalculator();

            //Act Phase.
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("MXN", principal), interestRate, new LoanTerm(termInYears));

            //Assert Phase.
            //No aplica, se realiza por NUnit.

            return monthlyPayment;
        }

        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestData), sourceName: "TestCases")]
        [TestCaseSource(typeof(MonthlyRepaymentCsvData), sourceName: "GetTestCases", methodParams: new object[] { "Data.csv" })]
        public void CalculateCorrectMonthlyRepayment_Centralized(
            decimal principal,
            decimal interestRate,
            int termInYears,
            decimal expectedMonthlyPayment)
        {
            //Arrange Phase.
            var sut = new LoanRepaymentCalculator();

            //Act Phase.
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("MXN", principal), interestRate, new LoanTerm(termInYears));

            //Assert Phase.
            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }

        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestDataWithReturn), sourceName: "TestCasesWR")]
        public decimal CalculateCorrectMonthlyRepayment_Centralized_SimplifiedTestCase(
            decimal principal,
            decimal interestRate,
            int termInYears)
        {
            //Arrange Phase.
            var sut = new LoanRepaymentCalculator();

            //Act Phase.
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("MXN", principal), interestRate, new LoanTerm(termInYears));

            //Assert Phase.
            //No aplica, la realiza NUnit.

            return monthlyPayment;
        }

        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentCsvData), sourceName: "GetTestCases", methodParams: new object[] { "Data.csv" })]
        public void CalculateCorrectMonthlyRepayment_CsvData(
            decimal principal,
            decimal interestRate,
            int termInYears,
            decimal expectedMonthlyPayment)
        {
            //Arrange Phase.
            var sut = new LoanRepaymentCalculator();

            //Act Phase.
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("MXN", principal), interestRate, new LoanTerm(termInYears));

            //Assert Phase.
            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }

        [Test]
        public void CalculateCorrectMonthlyRepayment_Combinatorial(
            [Values(100_000, 200_000, 300_000)] decimal principal,
            [Values(1.3, 2.5, 3.4)] decimal interestRate,
            [Values(10, 20, 30)] int termInYears)
        {
            //Arrange Phase.
            var sut = new LoanRepaymentCalculator();

            //Act Phase.
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("MXN", principal), interestRate, new LoanTerm(termInYears));

            //Assert Phase.
            //No aplica, pues con el uso de este enfoque de generación de datos de prueba, no se pretendé realizar aserciones respecto a un valor esperado,
            //simplemente ejecutar la funcionalidad con diferentes combinaciones de datos esperando que no genere alguna excepción no esperada.
        }

        [Test]
        public void CalculateCorrectMonthlyRepayment_Range(
            [Range(50_000, 1_000_000, 50_000)] decimal principal,
            [Range(0.50, 20.00, 0.50)] decimal interestRate,
            [Range(10, 30, 10)] int termInYears)
        {
            //Arrange Phase.
            var sut = new LoanRepaymentCalculator();

            //Act Phase.
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("MXN", principal), interestRate, new LoanTerm(termInYears));

            //Assert Phase.
            //No aplica, pues con el uso de este enfoque de generación de datos de prueba, no se pretendé realizar aserciones respecto a un valor esperado,
            //simplemente ejecutar la funcionalidad con diferentes combinaciones de datos esperando que no genere alguna excepción no esperada.
        }

        [Test]
        [Sequential]
        public void CalculateCorrectMonthlyRepayment_Sequential(
            [Values(200_000, 200_000, 500_000)] decimal principal,
            [Values(6.5, 10, 10)] decimal interestRate,
            [Values(30, 30, 30)] int termInYears,
            [Values(1264.14, 1755.14, 4387.86)] decimal expectedMonthlyPayment)
        {
            //Arrange Phase.
            var sut = new LoanRepaymentCalculator();

            //Act Phase.
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("MXN", principal), interestRate, new LoanTerm(termInYears));

            //Assert Phase.
            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }
    }
}