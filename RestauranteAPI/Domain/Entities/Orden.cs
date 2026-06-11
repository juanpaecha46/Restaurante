namespace RestauranteAPI.Domain.Entities;

public class Orden
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public DateTime FechaOrden { get; set; } = DateTime.UtcNow;
    public string Estado { get; set; } = "Pendiente"; // Pendiente, Confirmada, Preparando, Lista, Entregada, Cancelada
    public decimal Total { get; set; }
    public int MedioPagoId { get; set; }
    public MedioPago? MedioPago { get; set; }
    public string Tipo { get; set; } = "Local"; // Local, Domicilio, Reserva
    public ICollection<OrdenDetalle> Detalles { get; set; } = new List<OrdenDetalle>();

    /// <summary>
    /// Confirma la orden si tiene detalles
    /// </summary>
    public void Confirmar()
    {
        if (!Detalles.Any())
            throw new DomainException("No se puede confirmar una orden sin detalles.");

        if (Estado != "Pendiente")
            throw new DomainException("Solo se pueden confirmar órdenes en estado Pendiente.");

        Estado = "Confirmada";
    }

    /// <summary>
    /// Marca la orden como en preparación
    /// </summary>
    public void Preparar()
    {
        if (Estado != "Confirmada")
            throw new DomainException("Solo se pueden preparar órdenes confirmadas.");

        Estado = "Preparando";
    }

    /// <summary>
    /// Marca la orden como lista
    /// </summary>
    public void Listar()
    {
        if (Estado != "Preparando")
            throw new DomainException("Solo se pueden listar órdenes en preparación.");

        Estado = "Lista";
    }

    /// <summary>
    /// Marca la orden como entregada
    /// </summary>
    public void Entregar()
    {
        if (Estado != "Lista" && Estado != "Confirmada")
            throw new DomainException("Solo se pueden entregar órdenes listas o confirmadas.");

        Estado = "Entregada";
    }

    /// <summary>
    /// Cancela la orden
    /// </summary>
    public void Cancelar()
    {
        if (Estado == "Entregada" || Estado == "Cancelada")
            throw new DomainException($"No se puede cancelar una orden en estado {Estado}.");

        Estado = "Cancelada";
    }

    /// <summary>
    /// Calcula el total de la orden basado en los detalles
    /// </summary>
    public void CalcularTotal()
    {
        Total = Detalles.Sum(d => d.Subtotal);
    }

    /// <summary>
    /// Agrega un detalle a la orden
    /// </summary>
    public void AgregarDetalle(OrdenDetalle detalle)
    {
        if (Estado != "Pendiente")
            throw new DomainException("Solo se pueden agregar detalles a órdenes en Pendiente.");

        Detalles.Add(detalle);
        CalcularTotal();
    }

    /// <summary>
    /// Elimina un detalle de la orden
    /// </summary>
    public void EliminarDetalle(int detalleId)
    {
        if (Estado != "Pendiente")
            throw new DomainException("Solo se pueden eliminar detalles de órdenes en Pendiente.");

        var detalle = Detalles.FirstOrDefault(d => d.Id == detalleId);
        if (detalle != null)
        {
            Detalles.Remove(detalle);
            CalcularTotal();
        }
    }
}

public class OrdenDetalle
{
    public int Id { get; set; }
    public int OrdenId { get; set; }
    public Orden? Orden { get; set; }
    public int ProductoId { get; set; }
    public Producto? Producto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public ICollection<OrdenDetalleAdicion> Adiciones { get; set; } = new List<OrdenDetalleAdicion>();

    /// <summary>
    /// Calcula el subtotal del detalle incluyendo adiciones
    /// </summary>
    public decimal Subtotal
    {
        get
        {
            var precioProducto = PrecioUnitario * Cantidad;
            var precioAdiciones = Adiciones.Sum(a => a.Precio * Cantidad);
            return precioProducto + precioAdiciones;
        }
    }

    /// <summary>
    /// Crea un detalle con validaciones
    /// </summary>
    public static OrdenDetalle Crear(int productoId, int cantidad, decimal precioUnitario)
    {
        if (cantidad <= 0)
            throw new DomainException("La cantidad debe ser mayor a 0.");

        if (precioUnitario < 0)
            throw new DomainException("El precio unitario no puede ser negativo.");

        return new OrdenDetalle
        {
            ProductoId = productoId,
            Cantidad = cantidad,
            PrecioUnitario = precioUnitario
        };
    }

    /// <summary>
    /// Agrega una adición al detalle
    /// </summary>
    public void AgregarAdicion(OrdenDetalleAdicion adicion)
    {
        if (adicion == null)
            throw new DomainException("No se puede agregar una adición nula.");

        Adiciones.Add(adicion);
    }
}

public class OrdenDetalleAdicion
{
    public int Id { get; set; }
    public int OrdenDetalleId { get; set; }
    public OrdenDetalle? OrdenDetalle { get; set; }
    public int AdicionId { get; set; }
    public Adicion? Adicion { get; set; }
    public decimal Precio { get; set; }

    /// <summary>
    /// Crea una adición en detalle con validación
    /// </summary>
    public static OrdenDetalleAdicion Crear(int adicionId, decimal precio)
    {
        if (precio < 0)
            throw new DomainException("El precio de la adición no puede ser negativo.");

        return new OrdenDetalleAdicion
        {
            AdicionId = adicionId,
            Precio = precio
        };
    }
}
