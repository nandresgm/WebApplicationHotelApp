namespace WebApplicationHotelApp.Models.ComboHabitaciones
{
    public class ComboHabitacion
    {
        public int Id { get; set; }
        public string? NombreCombo { get; set; }
        public string? Descripcion { get; set; }
        public double DuracionEstadia { get; set; }
        public string? Comodidades { get; set; }
        public string? Disponibilidad { get; set; }
        public string? Cancelacion { get; set; }
        public string? Reservacion { get; set; }
        public string? NotasAdicionales { get; set; }
        public int CodigoPromo { get; set; }
        public string? OpcionesPersonalizadas { get; set; }
    }
}
