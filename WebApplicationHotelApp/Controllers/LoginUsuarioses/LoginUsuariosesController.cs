using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHotelApp.Models.Hotel;
using WebApplicationHotelApp.Models.LoginUsuarios;

namespace WebApplicationHotelApp.Controllers.LoginUsuarioses
{
    public class LoginUsuariosesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44365/api");
        private readonly HttpClient _client;
        public LoginUsuariosesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
 
            return View();
        }


        [HttpPost]
        public IActionResult IniciarSesion(LoginUsuarios LoginUsuarios)
        {
            try
            {
                LoginUsuarios datauser = new LoginUsuarios();
                string data = JsonConvert.SerializeObject(LoginUsuarios);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/LoginUsuarioses/IniciarSesion", content).Result;
                if (response.IsSuccessStatusCode)
                {



                    string dataUser = response.Content.ReadAsStringAsync().Result;
                    datauser = JsonConvert.DeserializeObject<LoginUsuarios>(dataUser);



                    TempData["successMessage"] = "Inicio de sesion";
                    return RedirectToAction("IndexAdmin");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                throw;
            }
            return View();

        }

        public IActionResult IndexAdmin()
        {

            return View();
        }



    }
}
