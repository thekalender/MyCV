using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceService
    {
        Task<List<Service>> GetList();
        Task<Service> Get(int id);
        Task Add(Service entity);
        Task Update(Service entity);
        Task Delete(int id);
    }
}
