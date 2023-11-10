using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private AutorDAO autorDAO = new AutorDAO();

        [HttpGet("autores")]
        public List<Autor> GetAutores()
        {
            return autorDAO.SeleccionarTodosConLibros();
        }

        [HttpGet("autor")]
        public Autor GetAutor(int id)
        {
            return autorDAO.SeleccionarConLibros(id);
        }

        [HttpPost("autor")]
        public IActionResult InsertarAutor([FromBody] Autor autor)
        {
            try
            {
                if (autorDAO.Insertar(autor.Nombre, autor.AutorId))
                {
                    return Ok("Autor insertado con éxito.");
                }
                else
                {
                    return BadRequest("Error al insertar el autor.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
