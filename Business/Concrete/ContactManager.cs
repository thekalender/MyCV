using Business.Abstract;
using DataAccess.Absract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public async Task Add(Contact entity)
        {
            await _contactDal.Add(entity);
        }

        public async Task Delete(int id)
        {
            await _contactDal.Delete(await Get(id));
        }

        public async Task<Contact> Get(int id)
        {
            return await _contactDal.Get(x => x.ContactId == id);
        }

        public async Task<List<Contact>> GetList()
        {
            return await _contactDal.GetList();
        }

        public async Task Update(Contact entity)
        {
            await _contactDal.Update(entity);
        }
    }  
}
