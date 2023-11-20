namespace WebApplicationHotelApp.Models.Factura
{
    public class Factura
    {
        public int Id { get; set; }
        public int Nit_Hotel { get; set; }
        public string? Nombre_Hotel { get; set; }
        public string? Nombre_Cliente { get; set; }
        public string? Cedula_Cliente { get; set; }
        public double Precio_Pagar { get; set; }
        public int IdReserva { get; set; }
    }
}
