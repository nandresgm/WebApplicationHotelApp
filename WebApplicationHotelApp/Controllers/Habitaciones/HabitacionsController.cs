using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.Habitacion;

namespace WebApplicationHotelApp.Controllers.Habitaciones
{
    public class HabitacionsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public HabitacionsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Habitacion> listHabitacione = new List<Habitacion>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Habitacions/GetHabitacion").Result;
            if (response.IsSuccessStatusCode) ;
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listHabitacione = JsonConvert.DeserializeObject<List<Habitacion>>(data);
            }
            return View(listHabitacione);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Habitacion habitacion)
        {
            try
            {
                string data = JsonConvert.SerializeObject(habitacion);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Habitacions/PostHabitacion", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "habitacion Creado";
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
                Habitacion habitacion = new Habitacion();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Habitacions/GetHabitacion/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    habitacion = JsonConvert.DeserializeObject<Habitacion>(data);

                }
                return View(habitacion);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(Habitacion habitacion)
        {
            try
            {
                string data = JsonConvert.SerializeObject(habitacion);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Habitacions/PutHabitacion/" + habitacion.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "habitacion Editado";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }
            return View(habitacion);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Habitacion habitacion = new Habitacion();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Habitacions/GetHabitacion/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    habitacion = JsonConvert.DeserializeObject<Habitacion>(data);
                }
                return View(habitacion);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Habitacions/DeleteHabitacion/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Habitacion Eliminado";
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
