namespace RestauranteAPI.Domain.Entities;

public class Reserva
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public int MesaId { get; set; }
    public Mesa? Mesa { get; set; }
    public int NumeroPersonas { get; set; }
    public DateTime FechaReserva { get; set; }
    public DateTime HoraReserva { get; set; }
    public string Estado { get; set; } = "Confirmada"; // Confirmada, Cancelada, Completada
    public string? Observaciones { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Valida que la reserva sea para una fecha futura
    /// </summary>
    public void ValidarFecha()
    {
        var fechaYHora = FechaReserva.Date.Add(HoraReserva.TimeOfDay);
        if (fechaYHora < DateTime.UtcNow)
            throw new ReservaFechaPasadaException();
    }

    /// <summary>
    /// Confirma la reserva después de validaciones
    /// </summary>
    public void Confirmar()
    {
        ValidarFecha();
        Estado = "Confirmada";
    }

    /// <summary>
    /// Cancela la reserva
    /// </summary>
    public void Cancelar()
    {
        if (Estado == "Completada")
            throw new DomainException("No se puede cancelar una reserva completada.");
        
        Estado = "Cancelada";
    }

    /// <summary>
    /// Marca la reserva como completada
    /// </summary>
    public void Completar()
    {
        if (Estado == "Cancelada")
            throw new DomainException("No se puede completar una reserva cancelada.");
        
        Estado = "Completada";
    }
}
