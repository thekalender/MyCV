using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCV.API.Model.ClmTwoExperienceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClmTwoExperincesController : ControllerBase
    {
        private IClmTwoExperinceService _clmTwoExperinceService;

        public ClmTwoExperincesController(IClmTwoExperinceService clmTwoExperinceService)
        {
            _clmTwoExperinceService = clmTwoExperinceService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            var model = new ClmTwoExperienceListViewModel
            {
                ClmTwoExperinces = await _clmTwoExperinceService.GetList()
            };
            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(ClmTwoExperince clmTwoExperince)
        {

            await _clmTwoExperinceService.Add(clmTwoExperince);
            return Ok();

        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var experinceModel = await _clmTwoExperinceService.Get(id);
            if (experinceModel != null)
            {
                var model = new ClmTwoExperienceUpdateViewModel
                {
                    ClmTwoExperince = new ClmTwoExperince
                    {
                        ExperinceId = experinceModel.ExperinceId,
                        Title = experinceModel.Title,
                        Description = experinceModel.Description,
                        ExperinceDate = experinceModel.ExperinceDate
                    }
                };
                return Ok(model);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(ClmTwoExperince clmTwoExperince)
        {
            if (clmTwoExperince != null)
            {
                await _clmTwoExperinceService.Update(clmTwoExperince);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var experinceModel = await _clmTwoExperinceService.Get(id);
            if (experinceModel != null)
            {
                await _clmTwoExperinceService.Delete(experinceModel.ExperinceId);
                return Ok();
            }
            return NotFound();
        }
    }
}
