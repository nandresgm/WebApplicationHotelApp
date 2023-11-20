using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.Reserva;

namespace WebApplicationHotelApp.Controllers.Reservas
{
    public class ReservasController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public ReservasController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Reserva> listReserva = new List<Reserva>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Reservas/GetReserva").Result;
            if (response.IsSuccessStatusCode) ;
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listReserva = JsonConvert.DeserializeObject<List<Reserva>>(data);
            }
            return View(listReserva);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reserva reserva)
        {
            try
            {
                string data = JsonConvert.SerializeObject(reserva);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Reservas/PostReserva", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Reserva Creado";
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
                Reserva reserva = new Reserva();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Reservas/GetReserva/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    reserva = JsonConvert.DeserializeObject<Reserva>(data);

                }
                return View(reserva);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(Reserva reserva)
        {
            try
            {
                string data = JsonConvert.SerializeObject(reserva);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Reservas/PutReserva/" + reserva.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Reserva Editado";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }
            return View(reserva);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Reserva reserva = new Reserva();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Reservas/GetReserva/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    reserva = JsonConvert.DeserializeObject<Reserva>(data);
                }
                return View(reserva);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Reservas/DeleteReserva/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Reserva Eliminado";
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
