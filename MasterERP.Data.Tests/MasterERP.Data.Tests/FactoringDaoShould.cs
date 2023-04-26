using MasterERP.Data.Tests.DataCaseTest;
using MasterERP.Entities;
using NUnit.Framework;

namespace MasterERP.Data.Tests
{
    public class FactoringDaoShould
    {
        FactoringDao sut;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            string connectionString =
                "data source=uredi-server-krezca-dev.database.windows.net,1433;initial catalog=UREDI-DB-KREZCA-DEV;persist security info=True;user id=uredi-server-admin-dev;password=u#R3d13R#P;multipleactiveresultsets=True;";
            sut = new FactoringDao(connectionString);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            sut.Dispose();
        }

        [Test]
        [TestCaseSource(typeof(ReturnNotNullFinancialCustomerData), "TestCases")]
        public void ReturnNotNullFinancialCustomer(int financialFactoringWithFinancialCustomerRelationShipId)
        {
            //Arrange Phase.
            FinancialFactoring ff_sut;

            //Act Phase.
            ff_sut = sut.SelectFinancialFactoring(financialFactoringWithFinancialCustomerRelationShipId);

            //Assert Phase.
            Assert.That(ff_sut, Is.Not.Null);
            Assert.That(ff_sut.FinancialCustomer, Is.Not.Null);
        }
    }
}