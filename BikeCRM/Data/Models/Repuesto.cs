using System;
using System.Collections.Generic;

namespace BikeCRM.Data.Models;

public partial class Repuesto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string? PrecioCompra { get; set; }

    public string? PrecioVenta { get; set; }

    public int? Stock { get; set; }

    public int? LowStock { get; set; }

    public string? Notas { get; set; }

    public int? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Servicio> Servicios { get; } = new List<Servicio>();
}
