using System;
using System.Collections.Generic;

namespace BikeCRM.Data.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Estado { get; set; }

    public virtual Estado EstadoNavigation { get; set; } = null!;
}
