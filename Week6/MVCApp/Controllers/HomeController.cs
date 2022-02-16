using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCApp.Models;
using McRobbie.Com;
using Newtonsoft.Json;
using System.Net.Http;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            // creating a client so we can make requests from an http resource
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            HttpResponseMessage response = await client.GetAsync("Characters/");
            string json = await response.Content.ReadAsStringAsync();
            
            IEnumerable<Character> characters = JsonConvert.DeserializeObject<IEnumerable<Character>>(json);
            
            // Simpsons db = new Simpsons();
            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                Heading = "Simpsons Characters",
                Characters = characters.ToList()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
