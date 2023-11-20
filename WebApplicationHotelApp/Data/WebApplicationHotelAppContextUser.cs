using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApplicationHotelApp.Models.Clientes;
using WebApplicationHotelApp.Models.ComboHabitaciones;
using WebApplicationHotelApp.Models.DetalleFacturas;
using WebApplicationHotelApp.Models.DetalleHabitacion;
using WebApplicationHotelApp.Models.DetalleReserva;
using WebApplicationHotelApp.Models.Empleado;
using WebApplicationHotelApp.Models.Factura;
using WebApplicationHotelApp.Models.Habitacion;
using WebApplicationHotelApp.Models.Hotel;
using WebApplicationHotelApp.Models.Reserva;
using WebApplicationHotelApp.Models.TipoDocumento;
using WebApplicationHotelApp.Models.TipoHabitacion;
using NuGet.ContentModel;

namespace WebApplicationHotelApp.Data
{
    public class WebApplicationHotelAppContextUser : DbContext
    {
        public WebApplicationHotelAppContextUser (DbContextOptions<WebApplicationHotelAppContextUser> options)
            : base(options)
        {
        }


        public DbSet<WebApplicationHotelApp.Models.Clientes.Cliente>? Cliente { get; set; }

        public DbSet<WebApplicationHotelApp.Models.ComboHabitaciones.ComboHabitacion>? ComboHabitacion { get; set; }

        public DbSet<WebApplicationHotelApp.Models.DetalleFacturas.DetalleFactura>? DetalleFactura { get; set; }

        public DbSet<WebApplicationHotelApp.Models.DetalleHabitacion.DetalleHabitacion>? DetalleHabitacion { get; set; }

        public DbSet<WebApplicationHotelApp.Models.DetalleReserva.DetalleReserva>? DetalleReserva { get; set; }

        public DbSet<WebApplicationHotelApp.Models.Empleado.Empleado>? Empleado { get; set; }

        public DbSet<WebApplicationHotelApp.Models.Factura.Factura>? Factura { get; set; }

        public DbSet<WebApplicationHotelApp.Models.Habitacion.Habitacion>? Habitacion { get; set; }

        public DbSet<WebApplicationHotelApp.Models.Hotel.Hotel>? Hotel { get; set; }

        public DbSet<WebApplicationHotelApp.Models.Reserva.Reserva>? Reserva { get; set; }

        public DbSet<WebApplicationHotelApp.Models.TipoDocumento.TipoDocumento>? TipoDocumento { get; set; }

        public DbSet<WebApplicationHotelApp.Models.TipoHabitacion.TipoHabitacion>? TipoHabitacion { get; set; }




    }
}
