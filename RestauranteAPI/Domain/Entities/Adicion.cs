using RestauranteAPI.Domain.Exceptions;

namespace RestauranteAPI.Domain.Entities;

public class Adicion
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
    public bool Activo { get; set; } = true;

    public static Adicion Crear(string nombre, decimal precio)
    {
        if (precio <= 0)
            throw new PrecioInvalidoException();

        return new Adicion
        {
            Nombre = nombre,
            Precio = precio
        };
    }

    public void ActualizarPrecio(decimal nuevoPrecio)
    {
        if (nuevoPrecio <= 0)
            throw new PrecioInvalidoException();

        Precio = nuevoPrecio;
    }
}
