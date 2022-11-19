using System;
using System.Collections.Generic;

namespace BikeCRM.Data.Models;

public partial class TipoServicio
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Servicio> Servicios { get; } = new List<Servicio>();
}
