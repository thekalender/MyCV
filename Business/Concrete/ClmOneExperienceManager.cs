using Business.Abstract;
using DataAccess.Absract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClmOneExperienceManager : IClmOneExperienceService
    {
        private IClmOneExperinceDal _clmOneExperinceDal;

        public ClmOneExperienceManager(IClmOneExperinceDal clmOneExperinceDal)
        {
            _clmOneExperinceDal = clmOneExperinceDal;
        }

        public async Task Add(ClmOneExperince entity)
        {
            await _clmOneExperinceDal.Add(entity);
        }

        public async Task Delete(int id)
        {
            await _clmOneExperinceDal.Delete(await Get(id));
        }

        public async Task<ClmOneExperince> Get(int id)
        {
            return await _clmOneExperinceDal.Get(x => x.ExperinceId == id);
        }

        public async Task<List<ClmOneExperince>> GetList()
        {
            return await _clmOneExperinceDal.GetList();
        }

        public async Task Update(ClmOneExperince entity)
        {
            await _clmOneExperinceDal.Update(entity);
        }
    }
}
