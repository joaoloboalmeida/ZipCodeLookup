using ConsultaCep.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiAJAX.Controllers
{
    public class CepController : Controller
    {
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> ConsultaCep(string id)
        {
            var url = $"https://viacep.com.br/ws/{id}/json";

             var client = new HttpClient();

            var data = await client.GetStringAsync(url);
            
            var retorno = JsonSerializer.Deserialize<Cep>(data);

            return Json(retorno);
        }
    }
}