using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.Empleado;

namespace WebApplicationHotelApp.Controllers.Empleados
{
    public class EmpleadoesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public EmpleadoesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Empleado> listEmpleado = new List<Empleado>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Empleadoes/GetEmpleado").Result;
            if (response.IsSuccessStatusCode) ;
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listEmpleado = JsonConvert.DeserializeObject<List<Empleado>>(data);
            }
            return View(listEmpleado);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            try
            {
                string data = JsonConvert.SerializeObject(empleado);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Empleadoes/PostEmpleado", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "empleado Creado";
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
                Empleado empleado = new Empleado();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Empleadoes/GetEmpleado/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    empleado = JsonConvert.DeserializeObject<Empleado>(data);

                }
                return View(empleado);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(Empleado empleado)
        {
            try
            {
                string data = JsonConvert.SerializeObject(empleado);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Empleadoes/PutEmpleado/" + empleado.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "empleado Editado";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }
            return View(empleado);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Empleado empleado = new Empleado();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Empleadoes/GetEmpleado/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    empleado = JsonConvert.DeserializeObject<Empleado>(data);
                }
                return View(empleado);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Empleadoes/DeleteEmpleado/" + id).Result;
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
