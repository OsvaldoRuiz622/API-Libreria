using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Operaciones
{
    public class AutorDAO
    {
        private LibreriaContext contexto;

        public AutorDAO()
        {
            contexto = new LibreriaContext();
        }

        // Método para seleccionar todos los autores
        public List<Autor> SeleccionarTodosConLibros()
        {
            var autoresConLibros = contexto.Autors
                .GroupJoin(contexto.Libros,
                    autor => autor.AutorId,
                    libro => libro.IdAutor,
                    (autor, libros) => new Autor
                    {
                        AutorId = autor.AutorId,
                        Nombre = autor.Nombre,
                        Libros = libros.ToList() // Asignamos la lista de libros
                    })
                .ToList();

            return autoresConLibros;
        }

        // Método para seleccionar un autor en específico por ID
        public Autor SeleccionarConLibros(int id)
        {
            var autorConLibros = contexto.Autors
                .Where(a => a.AutorId == id)
                .GroupJoin(contexto.Libros,
                    autor => autor.AutorId,
                    libro => libro.IdAutor,
                    (autor, libros) => new Autor
                    {
                        AutorId = autor.AutorId,
                        Nombre = autor.Nombre,
                        Libros = libros.ToList() // Asignamos la lista de libros
                    })
                .FirstOrDefault();

            return autorConLibros;
        }

        // Método para insertar un nuevo autor
        public bool Insertar(string nombre, int id)
        {
            try
            {
                Autor autor = new Autor();
                {
                    autor.AutorId = id;
                    autor.Nombre = nombre;
                    
                };

                contexto.Autors.Add(autor);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                return false;
            }
        }
    }
}
