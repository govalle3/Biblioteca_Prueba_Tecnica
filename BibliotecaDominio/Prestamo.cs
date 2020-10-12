using System;

namespace BibliotecaDominio
{
    public class Prestamo
    {
        public DateTime FechaSolicitud { get; set; }  // se instancia las clases con get y set necesarias
        public Libro Libro { get; set; }
        public DateTime? FechaEntregaMaxima { get; set; } // Se agregó un ? para permitir generar valores nulos.
        public string NombreUsuario { get;}

        public Prestamo(DateTime fechaSolicitud, Libro libro, DateTime? fechaEntregaMaxima, string nombreUsuario)
        {
            this.FechaSolicitud = fechaSolicitud;
            this.Libro = libro;
            this.FechaEntregaMaxima = fechaEntregaMaxima;
            this.NombreUsuario = nombreUsuario;
        }
    }
}
