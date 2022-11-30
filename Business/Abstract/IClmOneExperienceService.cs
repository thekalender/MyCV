using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IClmOneExperienceService
    {
        Task<List<ClmOneExperince>> GetList();
        Task<ClmOneExperince> Get(int id);
        Task Add(ClmOneExperince entity);
        Task Update(ClmOneExperince entity);
        Task Delete(int id);
    }
}
