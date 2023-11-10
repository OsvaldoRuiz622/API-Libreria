using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Operaciones
{
    public class LibroDAO
    {
        private LibreriaContext contexto;

        public LibroDAO()
        {
            contexto = new LibreriaContext();
        }

        // Método para seleccionar todos los libros
        public List<Libro> SeleccionarTodosConAutores()
        {
            var librosConAutores = contexto.Libros
                .Join(contexto.Autors,
                      libro => libro.IdAutor,
                      autor => autor.AutorId,
                      (libro, autor) => new Libro
                      {
                          IdLibro = libro.IdLibro,
                          Titulo = libro.Titulo,
                          Capitulos = libro.Capitulos,
                          Paginas = libro.Paginas,
                          Precio = libro.Precio,
                          IdAutor = libro.IdAutor,
                          IdAutorNavigation = autor // Asignamos el objeto Autor completo
                      })
                .ToList();

            return librosConAutores;
        }

        // Método para seleccionar un libro en específico por ID
        public Libro SeleccionarConAutor(int id)
        {
            var libroConAutor = contexto.Libros
                .Where(l => l.IdLibro == id)
                .Join(contexto.Autors,
                      libro => libro.IdAutor,
                      autor => autor.AutorId,
                      (libro, autor) => new Libro
                      {
                          IdLibro = libro.IdLibro,
                          Titulo = libro.Titulo,
                          Capitulos = libro.Capitulos,
                          Paginas = libro.Paginas,
                          Precio = libro.Precio,
                          IdAutor = libro.IdAutor,
                          IdAutorNavigation = autor // Asignamos el objeto Autor completo
                      })
                .FirstOrDefault();

            return libroConAutor;
        }

        // Método para insertar un nuevo libro
        public bool Insertar(int id,string titulo, int? capitulos, int? paginas, int? precio, int idAutor)
        {
            try
            {
                Libro libro = new Libro();
                {
                    libro.IdLibro = id;
                    libro.Titulo = titulo;
                    libro.Capitulos = capitulos;
                    libro.Paginas = paginas;
                    libro.Precio = precio;
                    libro.IdAutor = idAutor;
                };

                contexto.Libros.Add(libro);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex){return false;}
        }
    }
}
