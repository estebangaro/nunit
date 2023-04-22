using LoansNF.Domain.Applications;
using NUnit.Framework;

namespace Loans.Tests.Fixtures
{
    [TestFixture]
    public class LongTermShould
    {
        [Test]
        public void ReturnTermInMonths()
        {
            int años = 1; //Datos de entrada.
            int valorEsperado = 12; //Dato de salida esperado, pues 1 año equivale a 12 meses.
            var sut = new LoanTerm(años); //System under test (clase que contiene la funcionalidad para la cual el método fué creado).
            var valorDeSalida = sut.ToMonths(); //Funcionalidad a validar, propiedad Years de la clase LoanTerm.

            Assert.That(valorDeSalida, Is.EqualTo(valorEsperado)); //Uso de aserción, para validar el resultado de salida, respecto al valor esperado.
        }
    }
}