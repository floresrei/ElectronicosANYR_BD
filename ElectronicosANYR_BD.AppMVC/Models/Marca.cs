using System;
using System.Collections.Generic;

namespace ElectronicosANYR_BD.AppMVC.Models;

public partial class Marca
{
    public int MarcaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? PaisOrigen { get; set; }

    public string? SitioWeb { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
