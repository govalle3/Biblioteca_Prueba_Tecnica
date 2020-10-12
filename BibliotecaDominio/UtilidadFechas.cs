using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDominio;

namespace BibliotecaDominio
{
    class UtilidadFechas
    {
        private UtilidadFechas() { }

        public static DateTime ConvertirToDate(DateTime localDate)
        {
            return DateTime.Today;
        }

        public static DateTime AgregarDias(DateTime fechaSolicitud, int cantidadMaxima)
        {
            if (cantidadMaxima < 1)
            {
                return fechaSolicitud;
            }

            DateTime fechaIterador = fechaSolicitud;
            int diasAgregados = 1;
            while (diasAgregados < cantidadMaxima)
            {
                fechaIterador = fechaIterador.AddDays(1);
                if (!(fechaIterador.DayOfWeek == DayOfWeek.Sunday))
                {
                    ++diasAgregados;
                }
            }

            return fechaIterador;
        }
    }
}
