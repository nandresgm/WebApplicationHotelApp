using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.Factura;

namespace WebApplicationHotelApp.Controllers.Facturas
{
    public class FacturasController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public FacturasController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Factura> listFactura = new List<Factura>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Facturas/GetFactura").Result;
            if (response.IsSuccessStatusCode) ;
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listFactura = JsonConvert.DeserializeObject<List<Factura>>(data);
            }
            return View(listFactura);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Factura factura)
        {
            try
            {
                string data = JsonConvert.SerializeObject(factura);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Facturas/PostFactura", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "factura Creado";
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
                Factura factura = new Factura();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Facturas/GetFactura/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    factura = JsonConvert.DeserializeObject<Factura>(data);

                }
                return View(factura);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(Factura factura)
        {
            try
            {
                string data = JsonConvert.SerializeObject(factura);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Facturas/PutFactura/" + factura.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "factura Editado";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }
            return View(factura);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Factura factura = new Factura();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Facturas/GetFactura/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    factura = JsonConvert.DeserializeObject<Factura>(data);
                }
                return View(factura);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Facturas/DeleteFactura/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Factura Eliminado";
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
