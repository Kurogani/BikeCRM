using System;
using System.Collections.Generic;

namespace BikeCRM.Data.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Contrasena { get; set; }

    public int? Rol { get; set; }

    public int? Estado { get; set; }

    public string? Salt { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
