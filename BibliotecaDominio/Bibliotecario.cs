using BibliotecaDominio.IRepositorio;
using System;

namespace BibliotecaDominio
{
    public class Bibliotecario
    {

        public const string EL_LIBRO_NO_SE_ENCUENTRA_DISPONIBLE = "El libro no se encuentra disponible";
        public static String EL_LIBRO_SOLO_SE_PUEDE_USAR_EN_LA_BIBLIOTECA = "los libros palíndromos solo se pueden utilizar en la biblioteca";
        public static String EL_LIBRO_NO_EXISTE_EN_LA_BIBLIOTECA = "El libro no existe en la biblioteca";
        public static int NUMERO_SUMA_LIMITE_ISBN_ESPECIALES = 30; // regla de negocio declaradas
        public static int CANTIDAD_DIAS_MAXIMA_DE_ENTREGA = 15;
        private IRepositorioLibro libroRepositorio;       // creación de interfaces
        private  IRepositorioPrestamo prestamoRepositorio;

        public Bibliotecario(IRepositorioLibro libroRepositorio, IRepositorioPrestamo prestamoRepositorio)
        {
            this.libroRepositorio = libroRepositorio;
            this.prestamoRepositorio = prestamoRepositorio;
        }

        public void Prestar(string isbn, string nombreUsuario)
        {
            Libro libroParaPrestar = VerificarLibro(isbn);
            prestamoRepositorio.Agregar(ReglaDePrestamo(libroParaPrestar, nombreUsuario));
        }
        public bool EsPrestado(string isbn)
        {
            return prestamoRepositorio.ObtenerLibroPrestadoPorIsbn(isbn) != null ? true : false;
        }
        public Libro ObtenerLibro(String isbn) // estaba private, lo cambie en public
        {
            Libro libroParaPrestar = libroRepositorio.ObtenerPorIsbn(isbn); //Busqueda en la base de datos por medio de interfaz librorepositorio

            if (libroParaPrestar == null) // para que funcione no debe ser nulo
            {
                throw new NotImplementedException(EL_LIBRO_NO_EXISTE_EN_LA_BIBLIOTECA);
            }
            if (EsPalindromo(isbn))
            {
                throw new NotImplementedException(EL_LIBRO_SOLO_SE_PUEDE_USAR_EN_LA_BIBLIOTECA);
            }
          return libroParaPrestar;
        }

        public Libro VerificarLibro(String isbn)
        {
            if (EsPrestado(isbn))
            {
                throw new NotImplementedException(EL_LIBRO_NO_SE_ENCUENTRA_DISPONIBLE);
            }
            return ObtenerLibro(isbn);
        }
        public bool EsPalindromo(string Isbn)
        {

            char[] IsbnArray = Isbn.ToCharArray();
            Array.Reverse(IsbnArray); //objeto mutable
            return Isbn.Equals(new String(IsbnArray)); //TERMINAR LA FUNCION EN UNA SOLA LINEA
        }

        public int ObtenerNumeros(string isbn)
        {
            double numero = 0;
            for (int i = 0; i < isbn.Length; i++)
            {
                if (char.IsDigit(isbn[i]))
                {
                    numero = numero + char.GetNumericValue(isbn[i]);
                }
            }
            return Convert.ToInt32(numero);
        }

        private DateTime? ObtenerFechaEntregaMaxima(DateTime fechaSolicitud)
        {
            return UtilidadFechas.ConvertirToDate(UtilidadFechas.AgregarDias(fechaSolicitud, CANTIDAD_DIAS_MAXIMA_DE_ENTREGA));
        }

        public Prestamo ReglaDePrestamo(Libro libro, String nombreUsuario)
        {
            DateTime fechaSolicitud = new DateTime();
            DateTime? fechaNula = null;
            DateTime? fechaEntregaMaxima = ObtenerFechaEntrega(libro.Isbn,fechaSolicitud, fechaNula);
            return new Prestamo(UtilidadFechas.ConvertirToDate(fechaSolicitud), libro, fechaEntregaMaxima, nombreUsuario);
        }

        public DateTime? ObtenerFechaEntrega(String isbn, DateTime fechaSolicitud, DateTime? fechaNula)
        {
            return  (ObtenerNumeros(isbn) > NUMERO_SUMA_LIMITE_ISBN_ESPECIALES) ? ObtenerFechaEntregaMaxima(fechaSolicitud): fechaNula;
        }
    }
}


