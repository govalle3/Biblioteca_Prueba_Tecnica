﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaRepositorio.Entidades
{
    public class PrestamoEntidad
    {
        public int Id { get; set; }
        public int LibroEntidadId { get; set; }
        public LibroEntidad LibroEntidad { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaEntregaMaxima { get; set; } // Es necesario de agregar ? para permitir valores nulos
        public string NombreUsuario { get; set; }
    }
}
