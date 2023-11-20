namespace WebApplicationHotelApp.Models.Empleado
{
    public class Empleado
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public double NumeroCedula { get; set; }
        public string? CorreoElectronico { get; set; }
        public double Telefono { get; set; }
        public int IdHotel { get; set; }
    }
}
