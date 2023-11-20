using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.DetalleReserva;

namespace WebApplicationHotelApp.Controllers.DetalleReservas
{
    public class DetalleReservasController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public DetalleReservasController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<DetalleReserva> listDetalleReserva = new List<DetalleReserva>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/DetalleReservas/GetDetalleReservas").Result;
            if (response.IsSuccessStatusCode) ;
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listDetalleReserva = JsonConvert.DeserializeObject<List<DetalleReserva>>(data);
            }
            return View(listDetalleReserva);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DetalleReserva detalleReserva)
        {
            try
            {
                string data = JsonConvert.SerializeObject(detalleReserva);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/DetalleReservas/PostDetalleReservas", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "DetalleReservas Creado";
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
                DetalleReserva detalleReserva = new DetalleReserva();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/DetalleReservas/GetDetalleReservas/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    detalleReserva = JsonConvert.DeserializeObject<DetalleReserva>(data);

                }
                return View(detalleReserva);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(DetalleReserva detalleReserva)
        {
            try
            {
                string data = JsonConvert.SerializeObject(detalleReserva);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/DetalleReservas/PutDetalleReservas/" + detalleReserva.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Detalle Reservas Editado";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }
            return View(detalleReserva);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                DetalleReserva detalleReserva = new DetalleReserva();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/DetalleReservas/GetDetalleReservas/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    detalleReserva = JsonConvert.DeserializeObject<DetalleReserva>(data);
                }
                return View(detalleReserva);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/DetalleReservas/DeleteDetalleReservas/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Detall eReserva Eliminado";
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
