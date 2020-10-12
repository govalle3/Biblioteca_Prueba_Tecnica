using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DominioTest.Unitarias
{
    public class MetodoFecha
    {
        public MetodoFecha()
        {

        }

        public DateTime GenerarFechaEntregaMaxima(DateTime fechaIngreso, int diasSumar)
        {
            var FechaEntregaMaxima = SumarDiasSinContarEsDomingos(fechaIngreso, diasSumar);
            return FechaEntregaMaxima;
        }

        public DateTime SumarDiasSinContarEsDomingos(DateTime FechaSumar, int diasumar)
        {
            var diasAoperar = diasumar - 1;
            var fechaEntrega = new DateTime();
            while (diasAoperar > 0)
            {
                if (EsDomingo(FechaSumar))
                {
                    FechaSumar = FechaSumar.AddDays(1);
                    fechaEntrega = FechaSumar;
                    diasAoperar--;
                }
                else
                {
                    FechaSumar = FechaSumar.AddDays(1);
                    fechaEntrega = FechaSumar;
                }
            }
            return fechaEntrega;
        }

        public bool EsDomingo(DateTime fechaOperar)
        {
            return fechaOperar.DayOfWeek.ToString() != "Sunday" ? true : false;
        }


        [TestClass]
        public class testFEcha
        {
            [TestMethod]
            public void tetFechaEntrega()
            {
                // Arragne
                var fechasolicitud = new DateTime(2020, 10, 1); // Pasan 2 domingos para hacer entrega (17 oct)
               // var fechasolicitud = DateTime;
                var diasSumar = 15;
                MetodoFecha mf = new MetodoFecha();
                //Act
                var resultadoFecha = mf.SumarDiasSinContarEsDomingos(fechasolicitud, diasSumar);
                // Assert
                Assert.AreEqual("17", resultadoFecha.Day.ToString());
                Assert.AreEqual("10", resultadoFecha.Month.ToString());
                Assert.AreEqual("2020", resultadoFecha.Year.ToString());
            }
        }
    }
}

