using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private LibroDAO libroDAO = new LibroDAO();

        [HttpGet("libros")]
        public List<Libro> GetLibros()
        {
            return libroDAO.SeleccionarTodosConAutores();
        }

        [HttpGet("libro")]
        public Libro GetLibro(int id)
        {
            return libroDAO.SeleccionarConAutor(id);
        }

        [HttpPost("libro")]
        public IActionResult InsertarLibro([FromBody] Libro libro)
        {
            try
            {
                if (libroDAO.Insertar(libro.IdLibro,libro.Titulo, libro.Capitulos, libro.Paginas, libro.Precio, libro.IdAutor))
                {
                    return Ok("Libro insertado con éxito.");
                }
                else
                {
                    return BadRequest("Error al insertar el libro.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
