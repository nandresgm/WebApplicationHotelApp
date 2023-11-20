namespace WebApplicationHotelApp.Models.Habitacion
{
    public class Habitacion
    {
        public int Id { get; set; }
        public string? NombreOcupantes { get; set; }
        public int IdTipoHabitacion { get; set; }
        public string? Estado { get; set; }
        public string? Capacidad { get; set; }
        public int Piso { get; set; }
        public double PrecioPagar { get; set; }
        public int IdDetalleHabitacion { get; set; }
    }
}
