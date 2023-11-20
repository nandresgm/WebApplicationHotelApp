namespace WebApplicationHotelApp.Models.DetalleReserva
{
    public class DetalleReserva
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public int CantidaadNoches { get; set; }
        public int TipoHabitacion { get; set; }
        public int CantidadPersonas { get; set; }
        public string? FechaLlegada { get; set; }
        public string? FechaSalida { get; set; }
        public double PrecioTotal { get; set; }
    }
}
