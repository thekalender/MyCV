using Business.Abstract;
using DataAccess.Absract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        private IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public async Task Add(Service entity)
        {
            await _serviceDal.Add(entity);
        }

        public async Task Delete(int id)
        {
            await _serviceDal.Delete(await Get(id));
        }

        public async Task<Service> Get(int id)
        {
            return await _serviceDal.Get(x => x.ServiceId == id);
        }

        public async Task<List<Service>> GetList()
        {
            return await _serviceDal.GetList();
        }

        public async Task Update(Service entity)
        {
            await _serviceDal.Update(entity);
        }
    }
}
