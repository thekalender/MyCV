using Business.Abstract;
using DataAccess.Absract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task Add(About entity)
        {
            await _aboutDal.Add(entity);
        }

        public async Task Delete(int id)
        {
            await _aboutDal.Delete(await Get(id));
        }

        public async Task<About> Get(int id)
        {
            return await _aboutDal.Get(x => x.AboutId == id);
        }

        public async Task<List<About>> GetList()
        {
            return await _aboutDal.GetList();
        }

        public async Task Update(About entity)
        {
            await _aboutDal.Update(entity);
        }
    }
}
