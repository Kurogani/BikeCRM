using System;
using System.Collections.Generic;

namespace BikeCRM.Data.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string Nif { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Pais { get; set; }

    public string? Notas { get; set; }

    public int? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
