using Xunit;

public class ReservaServiceTests
{
    private readonly ReservaService servicio = new ReservaService();

    [Fact]
    public void CrearReservaValida()
    {
        var reserva = servicio.CrearReserva("Juan Pérez", DateTime.Now.AddDays(1));
        Assert.NotNull(reserva);
        Assert.Equal("Juan Pérez", reserva.Cliente);
    }

    [Fact]
    public void CrearReservaConFechaPasada()    
    {
        Assert.Throws<ArgumentException>(() => 
            servicio.CrearReserva("Ana López", DateTime.Now.AddDays(-1)));
    }

    [Fact]
    public void CrearReservaDuplicada()
    {
        var fecha = DateTime.Now.AddDays(2);
        servicio.CrearReserva("Cliente 1", fecha);
        Assert.Throws<InvalidOperationException>(() => 
            servicio.CrearReserva("Cliente 2", fecha));
    }

    [Fact]
    public void CancelarReservaExistente()
    {
        var reserva = servicio.CrearReserva("María García", DateTime.Now.AddDays(3));
        var resultado = servicio.CancelarReserva(reserva.Id);
        Assert.True(resultado);
    }

    [Fact]
    public void CancelarReservaInexistente()
    {
        var resultado = servicio.CancelarReserva(999);
        Assert.False(resultado);
    }
}