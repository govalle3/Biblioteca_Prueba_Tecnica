using BibliotecaDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioTest.TestDataBuilders
{
    public class LibroTestDataBuilder // construye objetos de informacion
    {
        //Definicion de valores para armar objeto de prueba
        private const int ANIO = 2012;
        private const string TITULO = "Cien años de soledad";   
        private const string ISBN = "1234";                    
        // cada vez que yo invoco el libro el iguaa los valroes en la linea 19 los valores internos
        // por defecto

            // atributos (permite libro.get.ano o libro.set.ano) permite sacar e introducir información
        public int Anio { get; set; }
        public string Isbn { get; set; }
        public string Titulo { get; set; }

        public LibroTestDataBuilder() // Coge los atributos del objeto libro y les asigna el valor por defecto (ineas 12 a las 13)
        {
            Anio = ANIO;
            Titulo = TITULO;
            Isbn = ISBN;
        }


        public LibroTestDataBuilder ConTitulo(string titulo)
        {
            Titulo = titulo;
            return this;
        }

        public LibroTestDataBuilder ConIsbn(string isbn)
        {
            Isbn = isbn;
            return this;
        }

        public LibroTestDataBuilder ConAnio(int anio)
        {
            Anio = anio;
            return this;
        }

        public Libro Build()
        {
            return new Libro(Isbn, Titulo, Anio); 
        }

    }
}
