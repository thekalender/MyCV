using Business.Abstract;
using DataAccess.Absract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClmOneSkillManager : IClmOneSkillService
    {
        private IClmOneSkillDal _clmOneSkillDal;

        public ClmOneSkillManager(IClmOneSkillDal clmOneSkillDal)
        {
            _clmOneSkillDal = clmOneSkillDal;
        }

        public async Task Add(ClmOneSkill entity)
        {
            await _clmOneSkillDal.Add(entity);
        }

        public async Task Delete(int id)
        {
            await _clmOneSkillDal.Delete(await Get(id));
        }

        public async Task<ClmOneSkill> Get(int id)
        {
            return await _clmOneSkillDal.Get(x => x.SkillId == id);
        }

        public async Task<List<ClmOneSkill>> GetList()
        {
            return await _clmOneSkillDal.GetList();
        }

        public async Task Update(ClmOneSkill entity)
        {
            await _clmOneSkillDal.Update(entity);
        }
    }
}
