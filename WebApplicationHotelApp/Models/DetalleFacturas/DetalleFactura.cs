namespace WebApplicationHotelApp.Models.DetalleFacturas
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }
        public double CostosAdicionales { get; set; }
        public double TotalPagar { get; set; }
        public int IdFactura { get; set; }
    }
}
