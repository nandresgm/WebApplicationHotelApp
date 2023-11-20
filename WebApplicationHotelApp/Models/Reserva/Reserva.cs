namespace WebApplicationHotelApp.Models.Reserva
{
    public class Reserva
    {
        public int Id { get; set; }
        public double FechaReserva { get; set; }
        public string? NombreCliente { get; set; }
        public double NumeroTelefonoCliente { get; set; }
        public string? CorreoElectronicoCliente { get; set; }
        public double FechaLlegada { get; set; }
        public double FechaSalida { get; set; }
        public int NumeroHabitacion { get; set; }
        public string? TipoHabitacion { get; set; }
        public string? MetodoPago { get; set; }
        public double TotalPagar { get; set; }
    }
}
