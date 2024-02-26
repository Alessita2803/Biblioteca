using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Añodepublicacion { get; set; }
        public int Numpag { get; set; }

 

        public Libro(string titulo, string autor, string genero, int añodepublicacion, int numpaginas)
        {
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
            Añodepublicacion = añodepublicacion;
            Numpag = numpaginas;

        }

        public Libro()
        {

        }
    }
}
