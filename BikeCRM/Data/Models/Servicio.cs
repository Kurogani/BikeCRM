using System;
using System.Collections.Generic;

namespace BikeCRM.Data.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string? UsuarioSolicitador { get; set; }

    public string? UsuarioResponsable { get; set; }

    public string? Nif { get; set; }

    public int? BiciId { get; set; }

    public int Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? TipoServicio { get; set; }

    public int? Prioridad { get; set; }

    public DateTime? FechaRecepcion { get; set; }

    public DateTime? FechaCompromiso { get; set; }

    public string? Repuesto { get; set; }

    public int? Costo { get; set; }

    public virtual Estado EstadoNavigation { get; set; } = null!;

    public virtual Prioridade? PrioridadNavigation { get; set; }

    public virtual Repuesto? RepuestoNavigation { get; set; }

    public virtual TipoServicio? TipoServicioNavigation { get; set; }
}
