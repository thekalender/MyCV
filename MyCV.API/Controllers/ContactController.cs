using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCV.API.Model.ContactViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
    
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new ContactListViewModel
            {
                Contacts = await _contactService.GetList()
            };
            return Ok(model);
        }

        public async Task<IActionResult>Delete(int id)
        {
            var modelId = await _contactService.Get(id);
            if (modelId != null)
            {
                await _contactService.Delete(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
