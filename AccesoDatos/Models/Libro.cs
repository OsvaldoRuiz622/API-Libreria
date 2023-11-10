using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? Titulo { get; set; }

    public int? Capitulos { get; set; }

    public int? Paginas { get; set; }

    public int? Precio { get; set; }

    public int IdAutor { get; set; }

    public virtual Autor? IdAutorNavigation { get; set; }
}
