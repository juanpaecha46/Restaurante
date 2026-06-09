namespace RestauranteAPI.Domain.Entities;

public class Orden
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public DateTime FechaOrden { get; set; } = DateTime.UtcNow;
    public string Estado { get; set; } = "Pendiente";
    public decimal Total { get; set; }
    public int MedioPagoId { get; set; }
    public MedioPago? MedioPago { get; set; }
    public string Tipo { get; set; } = "Local"; // Local, Domicilio, Reserva
    public ICollection<OrdenDetalle> Detalles { get; set; } = new List<OrdenDetalle>();
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
}

public class OrdenDetalleAdicion
{
    public int Id { get; set; }
    public int OrdenDetalleId { get; set; }
    public OrdenDetalle? OrdenDetalle { get; set; }
    public int AdicionId { get; set; }
    public Adicion? Adicion { get; set; }
    public decimal Precio { get; set; }
}
