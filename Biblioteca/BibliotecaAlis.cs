using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class BibliotecaAlis
    {
        public List<Libro> Libros = new List<Libro>();
        public List<Libro> Prestamo = new List<Libro>();

        public void AgregarLibro(Libro libro)
        {
            libro.Titulo = libro.Titulo.Trim();
            Libros.Add(libro);
        }


        public void MostrarLibros()
        {
            foreach (var libro in Libros)
            {
                Console.WriteLine("Título:" + libro.Titulo + " Autor:" + libro.Autor + " Género:" + libro.Genero + " Año de publicación:" + libro.Añodepublicacion + " Número de páginas:" + libro.Numpag + " páginas");
            }
        }

        public void PrestarLibro(string nombreLibro)
        {

            var libros = BuscarLibro(nombreLibro, 1, 0);

            if (libros != null)
            {
                int indice = 0;
                foreach (var libro in libros)
                {
                    indice++;
                    Console.WriteLine(indice + ".- Título:" + libro.Titulo + " Autor:" + libro.Autor + " Género:" + libro.Genero + " Año de publicación:" + libro.Añodepublicacion + " Número de páginas:" + libro.Numpag + " páginas");
                }

                Console.WriteLine("Selecciona el indice del libro: ");
                var indiceSelect = int.Parse(Console.ReadLine());


                Console.WriteLine("Para pedir prestado el libro, ingrese lo siguiente: ");

                Console.WriteLine("Fecha de préstamo: ");
                var fechaPres = Console.ReadLine();
                Console.WriteLine("Fecha de devolución: ");
                var fechaDev = Console.ReadLine();



                if (fechaDev != "" && fechaPres != "")

                {

                    var libro = libros.ElementAt
                        (indiceSelect - 1);

                    Console.WriteLine("Fecha del prestamo: " + fechaPres);
                    Console.WriteLine("Fecha de devolución: " + fechaDev);
                    Prestamo.Add(libro);
                    Libros.Remove(libro);

                } else
                {
                    Console.WriteLine("Para la próxima, ingresa las fechas");
                }
            }
            else
            {
                Console.WriteLine("El libro no existe");
            }

        }

        public List<Libro> BuscarLibro(string clave, int atributo, int lista) 
        {
            List<Libro> Buscados = new List<Libro>();

            List<Libro> Lista;
            if (lista == 0) Lista = Libros;
            else Lista = Prestamo;

          
            foreach (var libro in Lista)
            {
                if (atributo == 1)
                {
                    if (libro.Titulo == clave) Buscados.Add(libro);

                }
                else if (atributo == 2)
                {
                    if (libro.Autor == clave) Buscados.Add(libro);
                }
                else if (atributo == 3)
                {
                    if (libro.Genero == clave) Buscados.Add(libro);
                }
            }
            return Buscados;
        }

        public void DevolverLibro(string nombreLibro)
        {
            Libro libroADevolver = null;

            int indice = 0;
            var prestamos = BuscarLibro(nombreLibro, 1, 1);
            if (BuscarLibro(nombreLibro, 1, 0).Count == 0 && prestamos.Count == 0) Console.WriteLine("El libro no existe"); 
            else if (prestamos.Count == 0) Console.WriteLine("Este libro no se ha prestado");
            foreach (var libro in prestamos)
            {
                indice++;
                Console.WriteLine(indice + ".- Título:" + libro.Titulo + " Autor:" + libro.Autor + " Género:" + libro.Genero + " Año de publicación:" + libro.Añodepublicacion + " Número de páginas:" + libro.Numpag + " páginas");
    
            }
            if (indice > 0)
            {
                Console.WriteLine("Selecciona el índice que desea devolver");
                var indiceSelect = int.Parse(Console.ReadLine());

                libroADevolver = Prestamo.ElementAt(indiceSelect - 1);

                    Prestamo.Remove(libroADevolver);
                    Libros.Add(libroADevolver);
                    Console.WriteLine("Devolución completa");
               
            }          
        }
    }
}
