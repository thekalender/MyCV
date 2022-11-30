using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCV.API.Model.MainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private IAboutService _aboutService;
        private IServiceService _serviceService;
        private IClmOneExperienceService _clmOneExperienceService;
        private IClmTwoExperinceService _clmTwoExperinceService;
        private IClmOneSkillService _clmOneSkillService;
        private IClmTwoSkillService _clmTwoSkillService;
        private IContactService _contactService;

        public MainController(IAboutService aboutService, IServiceService serviceService, IClmOneExperienceService clmOneExperienceService, IClmTwoExperinceService clmTwoExperinceService, IClmOneSkillService clmOneSkillService, IClmTwoSkillService clmTwoSkillService, IContactService contactService)
        {
            _aboutService = aboutService;
            _serviceService = serviceService;
            _clmOneExperienceService = clmOneExperienceService;
            _clmTwoExperinceService = clmTwoExperinceService;
            _clmOneSkillService = clmOneSkillService;
            _clmTwoSkillService = clmTwoSkillService;
            _contactService = contactService;
        }

        /// <summary>
        /// Kullanıcıya ait tüm bilgileri getirir
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var model = new MainListViewModel
            {
                Abouts = await _aboutService.GetList(),
                Services = await _serviceService.GetList(),
                ClmOneExperinces =await _clmOneExperienceService.GetList(),
                ClmTwoExperinces = await _clmTwoExperinceService.GetList(),
                ClmOneSkills = await _clmOneSkillService.GetList(),
                ClmTwoSkills = await _clmTwoSkillService.GetList()
            };
            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(Contact contact)
        {
            await _contactService.Add(contact);
            return Ok();
        }

    }
}
