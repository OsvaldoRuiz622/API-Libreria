﻿using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Autor
{
    public int AutorId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
