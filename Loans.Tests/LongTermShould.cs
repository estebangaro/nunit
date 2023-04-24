using LoansNF.Domain.Applications;
using NUnit.Framework;

namespace Loans.Tests.Fixtures
{
    [TestFixture]
    public class LongTermShould
    {
        [Test]
        public void ReturnTermInMonths() //Para validar la conversión de AÑOS a MESES, del plazo del préstamo.
        {
            //Arrange Phase.
            int años = 1; //Datos de entrada.
            int valorEsperado = 12; //Dato de salida esperado, pues 1 año equivale a 12 meses.
            var sut = new LoanTerm(años); //System under test (clase que contiene la funcionalidad para la cual el método fué creado).

            //Act Phase
            var valorDeSalida = sut.ToMonths(); //Funcionalidad a validar, propiedad Years de la clase LoanTerm.

            //Assert Phase
            Assert.That(valorDeSalida, Is.EqualTo(valorEsperado)); //Uso de aserción y restricción, para validar el resultado de salida, respecto al valor esperado.
        }

        [Test]
        public void StoreYears() //Para validar que el valor proporcionado en el constructor de la clase LoanTerm, corresponda con el valor devuelto por la propiedad Years.
        {
            //Arrange Phase.
            int años = 2; //Dato de entrada y valor esperado.
            var sut = new LoanTerm(años); //system under test (clase que contiene la funcionalidad para la cual el método fué creado).

            //Act Phase.
            var valorDeSalida = sut.Years; //Recuperamos el valor almacenado en la propiedad Years.

            //Assert Phase
            Assert.That(valorDeSalida, Is.EqualTo(años)); //Utilizando el modelo de aserciones basado en restricciones, verificamos que el valor devuelto por la propiedad Years sea igual al valor proporcionado al constructor.
        }
    }
}