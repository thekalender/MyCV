using Business.Abstract;
using DataAccess.Absract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClmTwoSkillManager : IClmTwoSkillService
    {
        private IClmTwoSkillDal _clmTwoSkillDal;

        public ClmTwoSkillManager(IClmTwoSkillDal clmTwoSkillDal)
        {
            _clmTwoSkillDal = clmTwoSkillDal;
        }

        public async Task Add(ClmTwoSkill entity)
        {
            await _clmTwoSkillDal.Add(entity);
        }

        public async Task Delete(int id)
        {
            await _clmTwoSkillDal.Delete(await Get(id));
        }

        public async Task<ClmTwoSkill> Get(int id)
        {
            return await _clmTwoSkillDal.Get(x => x.SkillId == id);
        }

        public async Task<List<ClmTwoSkill>> GetList()
        {
            return await _clmTwoSkillDal.GetList();
        }

        public async Task Update(ClmTwoSkill entity)
        {
            await _clmTwoSkillDal.Update(entity);
        }
    }
}
