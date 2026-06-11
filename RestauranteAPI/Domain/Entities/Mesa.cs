namespace RestauranteAPI.Domain.Entities;

public class Mesa
{
    public int Id { get; set; }
    public int NumeroMesa { get; set; }
    public int Capacidad { get; set; }
    public string Ubicacion { get; set; } = null!;
    public bool Ocupada { get; set; } = false;
    public DateTime? FechaOcupacion { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Ocupa la mesa si está disponible
    /// </summary>
    public void Ocupar()
    {
        if (Ocupada)
            throw new MesaOcupadaException(NumeroMesa);

        Ocupada = true;
        FechaOcupacion = DateTime.UtcNow;
    }

    /// <summary>
    /// Libera la mesa si está ocupada
    /// </summary>
    public void Liberar()
    {
        if (!Ocupada)
            throw new MesaYaLibreException(NumeroMesa);

        Ocupada = false;
        FechaOcupacion = null;
    }
}
