using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IClmTwoSkillService
    {
        Task<List<ClmTwoSkill>> GetList();
        Task<ClmTwoSkill> Get(int id);
        Task Add(ClmTwoSkill entity);
        Task Update(ClmTwoSkill entity);
        Task Delete(int id);
    }
}
