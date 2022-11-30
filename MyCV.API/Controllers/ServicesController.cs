using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCV.API.Model.ServiceModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            var model = new ServiceListViewModel
            {
                Services = await _serviceService.GetList()
            };

            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult>Add(Service service)
        {
            await _serviceService.Add(service);
            return Ok();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var serviceModel =await _serviceService.Get(id);

            if (serviceModel != null)
            {
                var model = new ServiceUpdateViewModel
                {
                    Service = new Service()
                    {
                        ServiceId = serviceModel.ServiceId,
                        ServiceItem = serviceModel.ServiceItem,
                        Image = serviceModel.Image
                    }
                };
                return Ok(model);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(Service service)
        {
            var serviceId = await _serviceService.Get(service.ServiceId);
            if (serviceId != null)
            {
                await _serviceService.Update(service);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var serviceId = await _serviceService.Get(id);
            if (serviceId!=null)
            {
                await _serviceService.Delete(serviceId.ServiceId);
                return Ok(); 
            }
            return NotFound();
        }
    }
}
