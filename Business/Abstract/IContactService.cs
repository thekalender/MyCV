using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        Task<List<Contact>> GetList();
        Task<Contact> Get(int id);
        Task Add(Contact entity);
        Task Update(Contact entity);
        Task Delete(int id);
    }
}
