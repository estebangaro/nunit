using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Loans.Tests
{
    public class MonthlyRepaymentCsvData
    {
        public static IEnumerable GetTestCases(string csvFileName)
        {
            string[] csvLines = File.ReadAllLines(csvFileName);
            var testCases = new List<TestCaseData>();

            return csvLines.Select(line =>
            {
                string[] values = line.Split(',');
                decimal principal = decimal.Parse(values[0]);
                decimal interestRate = decimal.Parse(values[1]);
                int termInYears = int.Parse(values[2]);
                decimal expectedMonthlyPayment = decimal.Parse(values[3]);

                return new TestCaseData(principal, interestRate, termInYears, expectedMonthlyPayment);
            });
        }
    }
}