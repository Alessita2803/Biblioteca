// See https://aka.ms/new-console-template for more information

using Biblioteca;

var Biblioteca = new BibliotecaAlis();
int opción = 0;


do
{
    Console.WriteLine("BIENVENIDOS A LA BIBLIOTECA ALIS");
    Console.WriteLine("1.Agregar un libro");
    Console.WriteLine("2.Mostrar libros");
    Console.WriteLine("3.Prestar Libro");
    Console.WriteLine("4.Buscar libro");
    Console.WriteLine("5.Devolver un libro");
    Console.WriteLine("6.SALIR");

    Console.WriteLine("Seleccione una opción:");

    if (int.TryParse(Console.ReadLine(), out int númeroOpción)) opción = númeroOpción;

    switch (opción)
    {


        case 1:
            
            Console.Clear();
            Libro libro = new Libro();
            Console.WriteLine("Título: ");
            var titulo = Console.ReadLine();
            if (titulo == null) titulo = "";
            libro.Titulo = titulo;
            Console.WriteLine("Autor: ");
            var autor = Console.ReadLine();
            if (autor == null) autor = "";
            libro.Autor = autor;
            Console.WriteLine("Género: ");
            var genero = Console.ReadLine();
            if (genero == null) genero = "";
            libro.Genero = genero;

            Console.WriteLine("Año de publicación: ");


            if (int.TryParse(Console.ReadLine(), out int añoDePublicacion))
            {

                libro.Añodepublicacion = añoDePublicacion;
            }
            else
            {
                libro.Añodepublicacion = 0;
            }

            try
            {
                Console.WriteLine("Número de páginas: ");
                int numPag = 0;
                if (int.TryParse(Console.ReadLine(), out int númPag)) numPag = númPag;
                libro.Numpag = numPag;
            }
            catch
            {
                libro.Numpag = 0;
            }

            Biblioteca.AgregarLibro(libro);

            break;

        case 2:
            Console.Clear();
            Biblioteca.MostrarLibros();
            break;


        case 3:
            Console.Clear();
            Console.WriteLine("Nombre del libro que deseas pedir prestado: ");
            var nombreAPrestar = Console.ReadLine();
            if (nombreAPrestar == null) nombreAPrestar = "";
            Biblioteca.PrestarLibro(nombreAPrestar);

            break;

        case 4:
            Console.Clear();

            int opcion = 0;
            do
            {
                Console.WriteLine("Buscar por:");
                Console.WriteLine("1. Título");
                Console.WriteLine("2. Autor");
                Console.WriteLine("3. Género");
                Console.WriteLine("4. Regresar al menú principal");

                Console.WriteLine("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int númeroOpcion)) opcion = númeroOpcion;
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Ingrese el título: ");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Ingrese el autor: ");
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Ingrese el género: ");
                        break;
                }
                if (opcion < 4)
                {

                    var clave = Console.ReadLine();
                    if (clave == null) clave = "";

                    var libros = Biblioteca.BuscarLibro(clave, 1, 0);

                    var prestamos = Biblioteca.BuscarLibro(clave, 1, 1);

                    if (libros.Count == 0 && prestamos.Count == 0)
                    {
                        Console.WriteLine("El libro no existe");
                    }
            
                    foreach (var librito in libros)
                    {
                        Console.WriteLine("Título:" + librito.Titulo + " Autor:" + librito.Autor + " Género:" + librito.Genero + " Año de publicación:" + librito.Añodepublicacion + " Número de páginas:" + librito.Numpag + " páginas");
                    }

                    foreach (var librito in prestamos)
                    {
                        Console.WriteLine("Este libro está prestado: " + " Título:" + librito.Titulo + " Autor:" + librito.Autor + " Género:" + librito.Genero + " Año de publicación:" + librito.Añodepublicacion + " Número de páginas:" + librito.Numpag + " páginas");

                    }
                }
                
            } while (opcion < 4);
            break;

        case 5:
            Console.Clear();

            Console.WriteLine("Nombre del libro que deseas devolver: ");
            var nombreADevolver = Console.ReadLine();
            if (nombreADevolver == null) nombreADevolver = "";

            Biblioteca.DevolverLibro(nombreADevolver);

            break;
    }

} while (opción < 6);
