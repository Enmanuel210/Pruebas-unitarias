public class ReservaService
{
    private List<Reserva> reservas = new List<Reserva>();

    public Reserva CrearReserva(string cliente, DateTime fechaHora)
    {
        if (fechaHora < DateTime.Now)
            throw new ArgumentException("No se puede reservar en una fecha pasada");
        
        if (reservas.Any(r => r.FechaHora == fechaHora && r.Activa))
            throw new InvalidOperationException("Ya existe una reserva para esa fecha y hora");
        
        var reserva = new Reserva { Id = reservas.Count + 1, Cliente = cliente, FechaHora = fechaHora };
        reservas.Add(reserva);
        return reserva;
    }

    public bool CancelarReserva(int id)
    {
        var reserva = reservas.FirstOrDefault(r => r.Id == id && r.Activa);
        if (reserva == null)
            return false;
        
        reserva.Activa = false;
        return true;
    }
}