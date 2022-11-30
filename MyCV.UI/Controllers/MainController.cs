using Microsoft.AspNetCore.Mvc;
using MyCV.UI.Models.MainModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyCV.UI.Controllers
{
    public class MainController : Controller
    {
        public PartialViewResult _PartialHeader()
        {
            return PartialView();
        }


        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:18301/api/Main/GetAll");
            var jsonString = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<AboutListViewModel>(jsonString);

            return View(values);
        }
    }
}
