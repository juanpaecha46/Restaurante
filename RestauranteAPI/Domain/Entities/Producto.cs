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
    public int Stock { get; set; } = 0;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public ICollection<Adicion> Adiciones { get; set; } = new List<Adicion>();

    /// <summary>
    /// Crea un producto con validaciones de precio
    /// </summary>
    public static Producto Crear(string nombre, string descripcion, decimal precio, 
        string categoria, string? imagen = null, int stock = 0)
    {
        if (precio <= 0)
            throw new PrecioInvalidoException();

        if (stock < 0)
            throw new StockNegativoException();

        return new Producto
        {
            Nombre = nombre,
            Descripcion = descripcion,
            Precio = precio,
            Categoria = categoria,
            Imagen = imagen,
            Stock = stock
        };
    }

    /// <summary>
    /// Actualiza el precio con validación
    /// </summary>
    public void ActualizarPrecio(decimal nuevoPrecio)
    {
        if (nuevoPrecio <= 0)
            throw new PrecioInvalidoException();

        Precio = nuevoPrecio;
    }

    /// <summary>
    /// Aumenta el stock
    /// </summary>
    public void AumenrarStock(int cantidad)
    {
        if (cantidad < 0)
            throw new StockNegativoException();

        Stock += cantidad;
    }

    /// <summary>
    /// Reduce el stock
    /// </summary>
    public void ReducirStock(int cantidad)
    {
        if (cantidad < 0)
            throw new DomainException("La cantidad a reducir no puede ser negativa.");

        if (Stock - cantidad < 0)
            throw new StockNegativoException();

        Stock -= cantidad;
    }

    /// <summary>
    /// Verifica si hay stock disponible
    /// </summary>
    public bool HayStock(int cantidad = 1)
    {
        return Stock >= cantidad && Disponible;
    }
}
