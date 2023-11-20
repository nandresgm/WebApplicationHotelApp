using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.Clientes;

namespace WebApplicationHotelApp.Controllers.Clientes
{
    public class ClientesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public ClientesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Cliente> listCliente = new List<Cliente>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Clientes/GetClientes").Result;
            if (response.IsSuccessStatusCode) ;
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listCliente = JsonConvert.DeserializeObject<List<Cliente>>(data);
            }
            return View(listCliente);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            try
            {
                string data = JsonConvert.SerializeObject(cliente);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Clientes/PostClientes", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Cliente Creado";
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
                Cliente cliente = new Cliente();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Clientes/GetClientes/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    cliente = JsonConvert.DeserializeObject<Cliente>(data);

                }
                return View(cliente);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            try
            {
                string data = JsonConvert.SerializeObject(cliente);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Clientes/PutClientes/" + cliente.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Cliente Editado";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            try
            {
                Cliente cliente = new Cliente();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Clientes/GetClientes/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    cliente = JsonConvert.DeserializeObject<Cliente>(data);
                }
                return View(cliente);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }

        }


        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmado(int id)
        {

            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Clientes/DeleteClientes/" + id).Result;
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
