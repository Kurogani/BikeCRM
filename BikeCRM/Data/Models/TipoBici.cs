using System;
using System.Collections.Generic;

namespace BikeCRM.Data.Models;

public partial class TipoBici
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public int? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
