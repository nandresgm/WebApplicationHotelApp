using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.DetalleHabitacion;

namespace WebApplicationHotelApp.Controllers.DetalleHabitaciones
{
    public class DetallesHabitacionesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public DetallesHabitacionesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<DetalleHabitacion> listDetalleHabitacion = new List<DetalleHabitacion>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/DetallesHabitaciones/GetDetalleaHabitaciones").Result;
            if (response.IsSuccessStatusCode) ;
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listDetalleHabitacion = JsonConvert.DeserializeObject<List<DetalleHabitacion>>(data);
            }
            return View(listDetalleHabitacion);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DetalleHabitacion detalleHabitacion)
        {
            try
            {
                string data = JsonConvert.SerializeObject(detalleHabitacion);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/DetallesHabitaciones/PostDetalleaHabitaciones", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "detalleHabitacion Creado";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                throw;
            }
            return View();

        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                DetalleHabitacion detalleHabitacion = new DetalleHabitacion();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/DetallesHabitaciones/GetDetalleaHabitaciones/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    detalleHabitacion = JsonConvert.DeserializeObject<DetalleHabitacion>(data);

                }
                return View(detalleHabitacion);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(DetalleHabitacion detalleHabitacion)
        {
            try
            {
                string data = JsonConvert.SerializeObject(detalleHabitacion);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/DetallesHabitaciones/PutDetalleaHabitaciones/" + detalleHabitacion.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "detalle Habitacion Editado";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }
            return View(detalleHabitacion);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                DetalleHabitacion detalleHabitacion = new DetalleHabitacion();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/DetallesHabitaciones/GetDetalleaHabitaciones/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    detalleHabitacion = JsonConvert.DeserializeObject<DetalleHabitacion>(data);
                }
                return View(detalleHabitacion);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }

        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmado(int id)
        {

            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/DetallesHabitaciones/DeleteDetalleaHabitaciones/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Detalles Habitaciones Eliminado";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }

            return View();
        }
    }
}
