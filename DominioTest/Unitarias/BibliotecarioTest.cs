using System;
using System.Collections.Generic;
using System.Text;
using BibliotecaDominio;
using BibliotecaDominio.IRepositorio;
using DominioTest.TestDataBuilders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DominioTest.Unitarias
{
    [TestClass]
    public class BibliotecarioTest
    {
        public BibliotecarioTest()
        {

        }
        public Mock<IRepositorioLibro> repositorioLibro;
        public Mock<IRepositorioPrestamo> repositorioPrestamo;

        [TestInitialize]
        public void setup()
        {
            // Inicializar los mocks
           repositorioLibro = new Mock<IRepositorioLibro>();
           repositorioPrestamo = new Mock<IRepositorioPrestamo>();
        }

        [TestMethod]
        public void EsPrestado()
        {
            // Arrange
            var libroTestDataBuilder = new LibroTestDataBuilder();
            Libro libro = libroTestDataBuilder.Build();
            
            repositorioPrestamo.Setup(r => r.ObtenerLibroPrestadoPorIsbn(libro.Isbn)).Returns(libro);

            // Act
            Bibliotecario bibliotecario = new Bibliotecario(repositorioLibro.Object,repositorioPrestamo.Object);
            var esprestado = bibliotecario.EsPrestado(libro.Isbn);

            // Assert
            Assert.AreEqual(esprestado, true);
        }

        [TestMethod]
        public void LibroNoPrestadoTest()
        {
            // Arrange
            var libroTestDataBuilder = new LibroTestDataBuilder();
            Libro libro = libroTestDataBuilder.Build();
            Bibliotecario bibliotecario = new Bibliotecario(repositorioLibro.Object, repositorioPrestamo.Object);
            repositorioPrestamo.Setup(r => r.ObtenerLibroPrestadoPorIsbn(libro.Isbn)).Equals(null);

            // Act
            var esprestado = bibliotecario.EsPrestado(libro.Isbn);

            // Assert
            Assert.IsFalse(esprestado);
        }

        [TestMethod]
        public void esPalindromoTest(){
		String isbn = "A1221A";
		// instanciar la clase
		 Bibliotecario bibliotecario = new Bibliotecario(repositorioLibro.Object, repositorioPrestamo.Object); // inyeccion de dependencias
		
		Boolean esPalindromo = bibliotecario.EsPalindromo(isbn);
	
		Assert.IsTrue(esPalindromo);
	}
    [TestMethod]
    public void LanzarExceptionEsPalindromo()
        {
            // Arrange
            Bibliotecario bibliotecario = new Bibliotecario(repositorioLibro.Object, repositorioPrestamo.Object);
            string isbn = "B3223B";
            var libroTestDataBuilder = new LibroTestDataBuilder().ConIsbn(isbn);
            Libro libro = libroTestDataBuilder.Build();                               // Moquear ObtenerporISBN
            repositorioLibro.Setup(r => r.ObtenerPorIsbn(libro.Isbn)).Returns(libro); // lo que se instancia aca se llama r al llamar el meotodo obtener por isbn de la interfaz irepositorilibro
            // Act         
            try
            {
                Libro LibroTest = bibliotecario.ObtenerLibro(isbn);
                Assert.Fail(); // La prueba falló porque la excepcion no fue lanzada
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(Bibliotecario.EL_LIBRO_SOLO_SE_PUEDE_USAR_EN_LA_BIBLIOTECA , ex.Message.ToString()); // comparando el mensaje esperado y el lanzado.
            }      
    }
        [TestMethod]
        public void NoEsPalindromoTest()
        {
            // Arrange
            Bibliotecario bibliotecario = new Bibliotecario(repositorioLibro.Object, repositorioPrestamo.Object);
            string isbn = "B3283B";
            var libroTestDataBuilder = new LibroTestDataBuilder().ConIsbn(isbn);
            Libro libro = libroTestDataBuilder.Build(); //crea un libro para comparar                            // Moquear ObtenerporISBN
            repositorioLibro.Setup(r => r.ObtenerPorIsbn(libro.Isbn)).Returns(libro); // (MOCK) lo que se instancia aca se llama r al llamar el meotodo obtener por isbn de la interfaz irepositorilibro
            // linea 102 se retorna el libro que se acaba de crear
            // Act         
            Libro LibroTest = bibliotecario.ObtenerLibro(isbn);
            // Assert
            Assert.AreEqual(libro , LibroTest); // comparando el mensaje esperado y el lanzado.

        }

    }
}
