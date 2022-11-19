using System;
using System.Collections.Generic;

namespace BikeCRM.Data.Models;

public partial class Estado
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public string? Comentario { get; set; }

    public virtual ICollection<Role> Roles { get; } = new List<Role>();

    public virtual ICollection<Servicio> Servicios { get; } = new List<Servicio>();
}
