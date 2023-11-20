using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.ComboHabitaciones;

namespace WebApplicationHotelApp.Controllers.ComboHabitaciones
{
    public class ComboHabitacionesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public ComboHabitacionesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ComboHabitacion> listComboHabitacion = new List<ComboHabitacion>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/ComboHabitacions/GetComboHabitacion").Result;
            if (response.IsSuccessStatusCode) ;
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listComboHabitacion = JsonConvert.DeserializeObject<List<ComboHabitacion>>(data);
            }
            return View(listComboHabitacion);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ComboHabitacion comboHabitacion)
        {
            try
            {
                string data = JsonConvert.SerializeObject(comboHabitacion);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/ComboHabitacions/PostComboHabitacion", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "comboHabitacion Creado";
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
                ComboHabitacion comboHabitacion = new ComboHabitacion();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/ComboHabitacions/GetComboHabitacion/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    comboHabitacion = JsonConvert.DeserializeObject<ComboHabitacion>(data);

                }
                return View(comboHabitacion);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(ComboHabitacion comboHabitacion)
        {
            try
            {
                string data = JsonConvert.SerializeObject(comboHabitacion);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/ComboHabitacions/PutComboHabitacion/" + comboHabitacion.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "comboHabitacion Editado";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }
            return View(comboHabitacion);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                ComboHabitacion comboHabitacion = new ComboHabitacion();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/ComboHabitacions/GetComboHabitacion/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    comboHabitacion = JsonConvert.DeserializeObject<ComboHabitacion>(data);
                }
                return View(comboHabitacion);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/ComboHabitacions/DeleteComboHabitacion/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Cliente Eliminado";
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
