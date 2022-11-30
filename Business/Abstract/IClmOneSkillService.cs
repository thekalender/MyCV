using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IClmOneSkillService
    {
        Task<List<ClmOneSkill>> GetList();
        Task<ClmOneSkill> Get(int id);
        Task Add(ClmOneSkill entity);
        Task Update(ClmOneSkill entity);
        Task Delete(int id);
    }
}
