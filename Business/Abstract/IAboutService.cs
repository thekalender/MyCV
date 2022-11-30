using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        Task<List<About>> GetList();
        Task<About> Get(int id);
        Task Add(About entity);
        Task Update(About entity);
        Task Delete(int id);
    }
}
