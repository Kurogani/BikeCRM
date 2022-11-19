using System;
using System.Collections.Generic;

namespace BikeCRM.Data.Models;

public partial class Bici
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Tipo { get; set; }

    public string? Serial { get; set; }

    public string Nif { get; set; } = null!;

    public int? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
