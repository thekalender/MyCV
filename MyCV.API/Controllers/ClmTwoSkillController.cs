using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCV.API.Model.ClmTwoSkillViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClmTwoSkillController : ControllerBase
    {
        private IClmTwoSkillService _clmTwoSkillService;

        public ClmTwoSkillController(IClmTwoSkillService clmTwoSkillService)
        {
            _clmTwoSkillService = clmTwoSkillService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            var model = new ClmTwoSkillListViewModel
            {
                ClmTwoSkills = await _clmTwoSkillService.GetList()
            };
            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(ClmTwoSkill clmTwoSkill)
        {
            await _clmTwoSkillService.Add(clmTwoSkill);
            return Ok();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var clmTwoSkillModel = await _clmTwoSkillService.Get(id);

            var model = new ClmTwoSkillUpdateViewModel
            {
                ClmTwoSkill = new ClmTwoSkill
                {
                    SkillId = clmTwoSkillModel.SkillId,
                    SkillItem = clmTwoSkillModel.SkillItem,
                    SkillValue = clmTwoSkillModel.SkillValue
                }
            };
            return Ok(model);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult>Update(ClmTwoSkill clmTwoSkill)
        {
            var modelId = await _clmTwoSkillService.Get(clmTwoSkill.SkillId);
            if (modelId != null)
            {
                await _clmTwoSkillService.Update(clmTwoSkill);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var modelId = await _clmTwoSkillService.Get(id);
            if (modelId != null)
            {
                await _clmTwoSkillService.Delete(modelId.SkillId);
                return Ok();
            }
            return NotFound();
        }
    }
}
