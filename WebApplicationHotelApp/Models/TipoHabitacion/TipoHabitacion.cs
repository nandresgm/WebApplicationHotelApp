namespace WebApplicationHotelApp.Models.TipoHabitacion
{
    public class TipoHabitacion
    {
        public int Id { get; set; }
        public string? NombreTipoHabitacion { get; set; }
        public string? Descripcion { get; set; }
        public double Capacidad { get; set; }
        public string? Tamanio { get; set; }
        public string? Vistas { get; set; }
        public string? Comodidades { get; set; }
        public string? Imagenes { get; set; }
        public string? Disponibilidad { get; set; }
        public string? NotasAdicionales { get; set; }
        public string? PoliticaCancelacion { get; set; }
        public string? OpcionReserva { get; set; }
        public int IdHabitacion { get; set; }
        public int IdCliente { get; set; }
    }
}
