using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.TipoHabitacion;

namespace WebApplicationHotelApp.Controllers.TipoHabitaciones
{
    public class TipoHabitacionesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public TipoHabitacionesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<TipoHabitacion> listTipoHabitacion = new List<TipoHabitacion>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/TipoHabitacions/GetTipoHabitacion").Result;
            if (response.IsSuccessStatusCode);
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listTipoHabitacion = JsonConvert.DeserializeObject<List<TipoHabitacion>>(data);
            }
            return View(listTipoHabitacion);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoHabitacion tipoHabitacion)
        {
            try
            {
                string data = JsonConvert.SerializeObject(tipoHabitacion);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/TipoHabitacions/PostTipoHabitacion", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "tipoHabitacion Creado";
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
                TipoHabitacion tipoHabitacion = new TipoHabitacion();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/TipoHabitacions/GetTipoHabitacion/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    tipoHabitacion = JsonConvert.DeserializeObject<TipoHabitacion>(data);

                }
                return View(tipoHabitacion);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(TipoHabitacion tipoHabitacion)
        {
            try
            {
                string data = JsonConvert.SerializeObject(tipoHabitacion);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/TipoHabitacions/PutTipoHabitacion/" + tipoHabitacion.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "tipo Habitacion Editado";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }
            return View(tipoHabitacion);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                TipoHabitacion tipoHabitacion = new TipoHabitacion();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/TipoHabitacions/GetTipoHabitacion/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    tipoHabitacion = JsonConvert.DeserializeObject<TipoHabitacion>(data);
                }
                return View(tipoHabitacion);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/TipoHabitacions/DeleteTipoHabitacion/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Tipo Habitacion Eliminado";
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
