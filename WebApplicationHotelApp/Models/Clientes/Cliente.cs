using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationHotelApp.Models.Clientes
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        [Required]
        public string? Apellido { get; set; }
        [Required]
        public int IdTipoDocumento { get; set; }
        [Required]
        public string? NumeroDocumento { get; set; }
        [Required]
        public string? CorreoElectronico { get; set; }
        [Required]
        public string? Telefono { get; set; }
        [Required]
        public string? Direccion { get; set; }
        [Required]
        public int IdReserva { get; set; }
    }
}
