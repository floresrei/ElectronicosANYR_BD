using System;
using System.Collections.Generic;

namespace ElectronicosANYR_BD.AppMVC.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int? CategoriaId { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public int? MarcaId { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual Marca? Marca { get; set; }
}
