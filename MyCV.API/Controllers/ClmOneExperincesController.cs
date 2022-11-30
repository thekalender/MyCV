using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCV.API.Model.ClmOneExperienceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClmOneExperincesController : ControllerBase
    {
        private IClmOneExperienceService _clmOneExperienceService;

        public ClmOneExperincesController(IClmOneExperienceService clmOneExperienceService)
        {
            _clmOneExperienceService = clmOneExperienceService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            var model = new ClmOneExperienceListViewModel
            {
                ClmOneExperinces = await _clmOneExperienceService.GetList()
            };

            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(ClmOneExperince clmOneExperince)
        {
            await _clmOneExperienceService.Add(clmOneExperince);
            return Ok();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var skillModel =await _clmOneExperienceService.Get(id);

            if (skillModel!=null)
            {
                var model = new ClmOneExperienceUpdateViewModel
                {
                    ClmOneExperince = new ClmOneExperince()
                    {
                        ExperinceId = skillModel.ExperinceId,
                        Title=skillModel.Title,
                        ExperinceDate = skillModel.ExperinceDate,
                        Description = skillModel.Description                      
                    }
                };
                return Ok(model);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(ClmOneExperince clmOneExperince)
        {
            var skillId = await _clmOneExperienceService.Get(clmOneExperince.ExperinceId);
            if (skillId!=null)
            {
                await _clmOneExperienceService.Update(clmOneExperince);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var skillId = await _clmOneExperienceService.Get(id);
            if (skillId != null)
            {
                await _clmOneExperienceService.Delete(skillId.ExperinceId);
                return Ok();
            }
            return NotFound();
        }
    }
}
