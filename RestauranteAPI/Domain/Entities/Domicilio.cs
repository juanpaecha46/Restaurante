namespace RestauranteAPI.Domain.Entities;

public class Domicilio
{
    public int Id { get; set; }
    public int OrdenId { get; set; }
    public Orden? Orden { get; set; }
    public int DireccionId { get; set; }
    public Direccion? Direccion { get; set; }
    public int? RepartidorId { get; set; }
    public Usuario? Repartidor { get; set; }
    public string Estado { get; set; } = "Pendiente"; // Pendiente, Asignado, En Camino, Entregado, Cancelado
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaEntrega { get; set; }
    public string? Observaciones { get; set; }
}
