namespace RestauranteAPI.Models;

public class Inventario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public int Cantidad { get; set; }
    public string Unidad { get; set; } = null!; // kg, litro, unidad, etc.
    public decimal PrecioUnitario { get; set; }
    public int CantidadMinima { get; set; }
    public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
    public bool Activo { get; set; } = true;
}
