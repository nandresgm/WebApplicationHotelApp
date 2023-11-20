using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.DetalleFacturas;

namespace WebApplicationHotelApp.Controllers.DetalleFacturas
{
    public class DetalleFacturasController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public DetalleFacturasController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<DetalleFactura> listDetalleFactura = new List<DetalleFactura>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/DetalleFacturas/GetDetalleFacturas").Result;
            if (response.IsSuccessStatusCode) ;
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listDetalleFactura = JsonConvert.DeserializeObject<List<DetalleFactura>>(data);
            }
            return View(listDetalleFactura);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DetalleFactura detalleFactura)
        {
            try
            {
                string data = JsonConvert.SerializeObject(detalleFactura);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/DetalleFacturas/PostDetalleFacturas", content).Result;
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
                DetalleFactura detalleFactura = new DetalleFactura();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/DetalleFacturas/GetDetalleFacturas/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    detalleFactura = JsonConvert.DeserializeObject<DetalleFactura>(data);

                }
                return View(detalleFactura);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(DetalleFactura detalleFactura)
        {
            try
            {
                string data = JsonConvert.SerializeObject(detalleFactura);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/DetalleFacturas/PutDetalleFacturas/" + detalleFactura.Id, content).Result;
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
            return View(detalleFactura);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                DetalleFactura detalleFactura = new DetalleFactura();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/DetalleFacturas/GetDetalleFacturas/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    detalleFactura = JsonConvert.DeserializeObject<DetalleFactura>(data);
                }
                return View(detalleFactura);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/DetalleFacturas/DeleteDetalleFacturas/" + id).Result;
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
