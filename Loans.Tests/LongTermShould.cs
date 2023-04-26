using LoansNF.Domain.Applications;
using NUnit.Framework;
using System;
using System.Linq;

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
            Assert.That(valorDeSalida, Is.EqualTo(valorEsperado), "El valor de meses debe ser igual a 12 * número de años"); //Uso de aserción y restricción, para validar el resultado de salida, respecto al valor esperado.
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

        [Test]
        public void NotAllowZeroYears()
        {
            //Arrange Phase.
            int years = 0;

            //Act Phase.
            //No aplica.

            //Assert Phase.
            //Assert.That(delegate
            //{
            //    var loanTerm_sut = new LoanTerm(years);
            //}, Throws.TypeOf<ArgumentOutOfRangeException>());

            //More specific equivalent asertion.
            //Assert.That(delegate
            //{
            //    var loanTerm_sut = new LoanTerm(years);
            //}, Throws.TypeOf<ArgumentOutOfRangeException>()
            //    .With
            //    .Matches<Exception>(exception => exception.Message.Equals("Please specify a value greater than 0.\r\nParameter name: years")));

            //Assert.That(delegate
            //{
            //    var loanTerm_sut = new LoanTerm(years);
            //}, Throws.TypeOf<ArgumentOutOfRangeException>()
            //    .With
            //    .Property("Message").Contains("Please specify a value greater than 0"));

            Assert.That(delegate
            {
                var loanTerm_sut = new LoanTerm(years);
            }, Throws.TypeOf<ArgumentOutOfRangeException>()
                .With
                .Message
                .EqualTo("Please specify a value greater than 0.\r\nParameter name: years"));
        }

        #region Métodos de prueba para ejemplificar el uso de aserciones

        [Test]
        public void NullValue()
        {
            //Arrange Phase.
            //No aplica.

            //Act Phase.
            string inputValue = "String";

            //Assert Phase.
            Assert.That(inputValue, Is.Not.Null);
        }

        [Test]
        public void EmptyStringValue()
        {
            //Arrange Phase.
            //No aplica.

            //Act Phase.
            string inputValue = "String";

            //Assert Phase.
            Assert.That(inputValue, Is.Not.Empty);
        }

        [Test]
        public void EqualityStringValue()
        {
            //Arrange Phase.
            string respectValue = "String";

            //Act Phase.
            string inputValue = "String";

            //Assert Phase.
            Assert.That(inputValue, Is.EqualTo(respectValue));

            Assert.That(inputValue, Is.EqualTo(respectValue).IgnoreCase);
        }

        [Test]
        public void SubstringValue()
        {
            //Arrange Phase.
            string startsWithValue = "St";
            string notStartsWithValue = "Rf";
            string endsWithValue = "ng";
            string containsValue = "rin";

            //Act Phase.
            string inputValue = "String";

            //Assert Phase.
            Assert.That(inputValue, Does.Contain(containsValue));
            Assert.That(inputValue, Does.StartWith(startsWithValue));
            Assert.That(inputValue, Does.Not.StartWith(notStartsWithValue));
            Assert.That(inputValue, Does.EndWith(endsWithValue));
            Assert.That(inputValue, Does.StartWith(startsWithValue).And.EndWith(endsWithValue));
        }

        [Test]
        public void BooleanValue()
        {
            //Arrange Phase.
            bool value = true;

            //Act Phase.
            //No aplica.

            //Assert Phase.
            Assert.That(value, Is.True);
            Assert.That(value, Is.Not.False);
            Assert.That(value);
            Assert.That(value == true);
        }

        [Test]
        public void NumericRangesValue()
        {
            //Arrange Phase.
            int value = 42;

            //Act Phase.
            //No aplica.

            //Assert Phase.
            Assert.That(value, Is.Not.GreaterThan(value));
            Assert.That(value, Is.GreaterThanOrEqualTo(value));
            Assert.That(value, Is.Not.LessThan(value));
            Assert.That(value, Is.LessThanOrEqualTo(value));
            Assert.That(value, Is.InRange(40, 50));
        }

        [Test]
        public void DateRangesValue()
        {
            //Arrange Phase.
            var d1 = DateTime.Today;
            var d2 = DateTime.Today.AddDays(2);

            //Act Phase.
            //No aplica.

            //Assert Phase.
            Assert.That(d1, Is.Not.EqualTo(d2)); //d2 no sea igual a d2...
            Assert.That(d1, Is.EqualTo(d2).Within(2).Days); //d1 es igual a d2 con una tolerancia de +/- 2 días...

            Assert.That(d1, Is.Not.GreaterThan(d2)); //d1 no es mayor a d2...
            Assert.That(d1, Is.LessThan(d2)); //d1 es menor a d2...
            Assert.That(d1, Is.LessThanOrEqualTo(d2)); //d1 es menor o igual a d2...
            Assert.That(d1, Is.InRange(DateTime.Today.AddDays(-1), DateTime.Today.AddDays(5))); //d1 se encuentra entre d1 - 1 día y d1 + 5 días.
        }

        [Test]
        [EqualityComparision]
        public void RespectValueEquality()
        {
            //Arreage Phase.
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);

            //Act Phase.
            //No aplica.

            //Assert Phase.
            Assert.That(a, Is.EqualTo(b));
            //Equivalent
            //Assert.That(a, new NUnit.Framework.Constraints.EqualConstraint(b));
        }

        [Test]
        [EqualityComparision]
        public void RespectValueInequality()
        {
            //Arreage Phase.
            var a = new LoanTerm(1);
            var b = new LoanTerm(2);

            //Act Phase.
            //No aplica.

            //Assert Phase.
            Assert.That(a, Is.Not.EqualTo(b));
            //Equivalent
            //Assert.That(a, new NUnit.Framework.Constraints.ConstraintExpression().Not.EqualTo(new NUnit.Framework.Constraints.EqualConstraint(b)));
        }

        [Test]
        public void RespectReferenceValueInequality()
        {
            //Arrange Phase.
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);

            //Act Phase.
            //No aplica.

            //Assert Phase.
            Assert.That(a, Is.Not.SameAs(b));
        }

        [Test]
        public void Double()
        {
            //Arrange Phase.
            double respectResult = 0.33;
            double operand1 = 1.0;
            double operand2 = 3.0;
            double amountTolerance = Math.Round(0.004, 3, MidpointRounding.AwayFromZero);
            double amountPercentageTolerance = 10;

            //Act Phase.
            double result = operand1 / operand2;

            //Assert Phase.
            Assert.That(result, Is.EqualTo(respectResult).Within(amountTolerance));
            Assert.That(result, Is.EqualTo(respectResult).Within(amountPercentageTolerance).Percent);
        }

        [Test]
        public void RespectReferenceValueEquality_ValueType()
        {
            //Arrange Phase.
            System.Collections.Generic.List<StructExample_1> list = new System.Collections.Generic.List<StructExample_1>
            {
                new StructExample_1 { String = "1", Integer = 1, Boolean = true },
                new StructExample_1 { String = "2", Integer = 2, Boolean = false },
                new StructExample_1 { String = "1", Integer = 1, Boolean = true }
            };
            var RespectGroupedListCount = 2;

            //Act Phase.
            var groupedList = list.GroupBy(item => item);
            var groupedListCount = groupedList.Count();

            //Assert Phase.
            Assert.That(groupedListCount, Is.EqualTo(RespectGroupedListCount));
        }

        [Test]
        public void RespectReferenceValueEquality_ValueType2()
        {
            //Arrange Phase.
            var string1 = new string(new char[] { 's', 't', 'r', 'i', 'n', 'g', '1' });
            var string11 = "string1";
            var string12 = "string1";
            string string2 = new string(new char[] { 's', 't', 'r', 'i', 'n', 'g', '1' });

            //Act Phase.
            //No aplica.

            //Assert Phase.
            Assert.That(string1, Is.Not.SameAs(string2));
            Assert.That(string11, Is.SameAs(string12));
        }

        [Test]
        public void RespectReferenceValueEquality_ValueType3()
        {
            //Arrange Phase.
            var list1 = new System.Collections.Generic.List<string> { "a", "b" };
            var list2 = new System.Collections.Generic.List<string> { "a", "b" };

            //Act Phase.
            //No aplica.

            //Assert Phase.
            Assert.That(list1, Is.Not.SameAs(list2));
            Assert.That(list1, Is.EqualTo(list2));
        }

        #endregion
    }
}