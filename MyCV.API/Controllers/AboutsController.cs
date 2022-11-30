using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCV.API.Model.AboutModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Update(int id)
        {
          var res=  await _aboutService.Get(id);

            var model = new AboutUpdateViewModel
            {
                About = new About
                {
                    AboutId = res.AboutId,
                    Name = res.Name,
                    Mail = res.Mail,
                    Phone =res.Phone,
                    Address = res.Address,
                    Age = res.Age,
                    Description=res.Description,
                    Status = res.Status
                }
            };
            return Ok(model);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(About about)
        {
            var aboutId = await _aboutService.Get(about.AboutId);
            if (aboutId!=null)
            {
                await _aboutService.Update(about);
                return Ok();
            }
            return NotFound();
        }
    }
}
