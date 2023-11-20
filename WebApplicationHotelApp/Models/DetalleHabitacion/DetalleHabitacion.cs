namespace WebApplicationHotelApp.Models.DetalleHabitacion
{
    public class DetalleHabitacion
    {
        public int Id { get; set; }
        public int IdHabitacion { get; set; }
        public int IdCliente { get; set; }
        public string? EstadoHabitacion { get; set; }
        public string? FechaLlegada { get; set; }
        public string? FechaSalida { get; set; }
        public string? MetodoPago { get; set; }
        public double TotalPagar { get; set; }
    }
}
