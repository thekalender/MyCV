using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MyCV.API.Model.ServiceModel;
using MyCV.UI.Models.MainModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyCV.UI.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AboutListViewModel
            {
                Service = new Service()
            };
            return View(model);
        }

        public async Task<IActionResult> Add(Service service)
        {
            var httpClient = new HttpClient();
            var jsonString = JsonConvert.SerializeObject(service);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:18301/api/Services/Add", content);

            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            return View(service);
        }
    }
}
