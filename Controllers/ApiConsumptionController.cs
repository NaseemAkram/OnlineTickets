using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineTickets.Models.Api_Consumption;

namespace OnlineTickets.Controllers
{
    public class ApiConsumptionController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44364/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //get Method
                HttpResponseMessage response = await client.GetAsync("api/employee");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    List<Employee> emp = JsonConvert.DeserializeObject<List<Employee>>(result);
                    return View(emp);
                }
                else
                {
                    return View();
                }
            }

        }
    }
}
