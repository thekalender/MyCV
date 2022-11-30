using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCV.API.Model.ClmOneSkillModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClmOneSkillController : ControllerBase
    {
        private IClmOneSkillService _clmOneSkillService;

        public ClmOneSkillController(IClmOneSkillService clmOneSkillService)
        {
            _clmOneSkillService = clmOneSkillService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            var model = new ClmOneSkillListViewModel
            {
                ClmOneSkills = await _clmOneSkillService.GetList()
            };
            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(ClmOneSkill clmOneSkill)
        {
            await _clmOneSkillService.Add(clmOneSkill);
            return Ok();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult>Update(int id)
        {
            var clmOneSkillModel = await _clmOneSkillService.Get(id);

            var model = new ClmOneSkillUpdateViewModel
            {
               ClmOneSkill=  new ClmOneSkill
                {
                    SkillId = clmOneSkillModel.SkillId,
                    SkillItem = clmOneSkillModel.SkillItem,
                    SkillValue = clmOneSkillModel.SkillValue
                }
            };
            return Ok(model);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult>Update(ClmOneSkill clmOneSkill)
        {
            var modelId = await _clmOneSkillService.Get(clmOneSkill.SkillId);
            if (modelId != null)
            {
                await _clmOneSkillService.Update(clmOneSkill);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var modelId = await _clmOneSkillService.Get(id);
            if (modelId != null)
            {
                await _clmOneSkillService.Delete(modelId.SkillId);
                return Ok();
            }
            return NotFound();
        }
    }
}
