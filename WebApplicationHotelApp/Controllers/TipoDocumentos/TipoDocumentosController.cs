using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.TipoDocumento;

namespace WebApplicationHotelApp.Controllers.TipoDocumentos
{
    public class TipoDocumentosController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public TipoDocumentosController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<TipoDocumento> listTipoDocumento = new List<TipoDocumento>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/TipoDocumentoes/GetTipoDocumento").Result;
            if (response.IsSuccessStatusCode) ;
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listTipoDocumento = JsonConvert.DeserializeObject<List<TipoDocumento>>(data);
            }
            return View(listTipoDocumento);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoDocumento tipoDocumento)
        {
            try
            {
                string data = JsonConvert.SerializeObject(tipoDocumento);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/TipoDocumentoes/PostTipoDocumento", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "tipoDocumento Creado";
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
                TipoDocumento tipoDocumento = new TipoDocumento();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/TipoDocumentoes/GetTipoDocumento/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    tipoDocumento = JsonConvert.DeserializeObject<TipoDocumento>(data);

                }
                return View(tipoDocumento);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(TipoDocumento tipoDocumento)
        {
            try
            {
                string data = JsonConvert.SerializeObject(tipoDocumento);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/TipoDocumentoes/PutTipoDocumento/" + tipoDocumento.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "tipoDocumento Editado";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }
            return View(tipoDocumento);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                TipoDocumento tipoDocumento = new TipoDocumento();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/TipoDocumentoes/GetTipoDocumento/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    tipoDocumento = JsonConvert.DeserializeObject<TipoDocumento>(data);
                }
                return View(tipoDocumento);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/TipoDocumentoes/DeleteTipoDocumento/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Tipo Documento Eliminado";
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
