namespace RestauranteAPI.Domain.Entities;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public decimal Precio { get; set; }
    public string Categoria { get; set; } = null!;
    public bool Disponible { get; set; } = true;
    public string? Imagen { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public ICollection<Adicion> Adiciones { get; set; } = new List<Adicion>();
}
