using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.Hotel;

namespace WebApplicationHotelApp.Controllers.Hotels
{
    public class HotelsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public HotelsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Hotel> listHotel = new List<Hotel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Hotels/GetHotel").Result;
            if (response.IsSuccessStatusCode) ;
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listHotel = JsonConvert.DeserializeObject<List<Hotel>>(data);
            }
            return View(listHotel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(hotel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Hotels/PostHotel", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "hotel Creado";
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
                Hotel hotel = new Hotel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Hotels/GetHotel/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    hotel = JsonConvert.DeserializeObject<Hotel>(data);

                }
                return View(hotel);
            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(Hotel hotel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(hotel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Hotels/PutHotel/" + hotel.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "hotel Editado";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errorMensage"] = ex.Message;
                return View();
            }
            return View(hotel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Hotel hotel = new Hotel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Hotels/GetHotel/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    hotel = JsonConvert.DeserializeObject<Hotel>(data);
                }
                return View(hotel);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Hotels/DeleteHotel/" + id).Result;
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
