using Business.Abstract;
using DataAccess.Absract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClmTwoExperienceManager : IClmTwoExperinceService
    {
        private IClmTwoExperinceDal _clmTwoExperinceDal;

        public ClmTwoExperienceManager(IClmTwoExperinceDal clmTwoExperinceDal)
        {
            _clmTwoExperinceDal = clmTwoExperinceDal;
        }

        public async Task Add(ClmTwoExperince entity)
        {
            await _clmTwoExperinceDal.Add(entity);
        }

        public async Task Delete(int id)
        {
            await _clmTwoExperinceDal.Delete(await Get(id));
        }

        public async Task<ClmTwoExperince> Get(int id)
        {
            return await _clmTwoExperinceDal.Get(x => x.ExperinceId == id);
        }

        public async Task<List<ClmTwoExperince>> GetList()
        {
            return await _clmTwoExperinceDal.GetList();
        }

        public async Task Update(ClmTwoExperince entity)
        {
            await _clmTwoExperinceDal.Update(entity);
        }
    }
}
