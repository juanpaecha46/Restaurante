namespace RestauranteAPI.Models;

public class Factura
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public int OrdenId { get; set; }
    public Orden? Orden { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal SubTotal { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; } = "Pendiente"; // Pendiente, Pagada, Cancelada
    public string? Observaciones { get; set; }
}
