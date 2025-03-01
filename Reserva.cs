public class Reserva
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public DateTime FechaHora { get; set; }
    public bool Activa { get; set; } = true;
}