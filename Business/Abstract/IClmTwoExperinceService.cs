using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IClmTwoExperinceService
    {
        Task<List<ClmTwoExperince>> GetList();
        Task<ClmTwoExperince> Get(int id);
        Task Add(ClmTwoExperince entity);
        Task Update(ClmTwoExperince entity);
        Task Delete(int id);
    }
}
