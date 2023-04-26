using NUnit.Framework;
using System.Collections;

namespace MasterERP.Data.Tests.DataCaseTest
{
    public class ReturnNotNullFinancialCustomerData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(1);
                yield return new TestCaseData(3);
                yield return new TestCaseData(5);
                yield return new TestCaseData(7);
            }
        }
    }
}
