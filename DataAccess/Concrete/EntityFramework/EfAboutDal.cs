using Core.DataAccess.EntityFramework;
using DataAccess.Absract;
using DataAccess.Concrete.ContextLibrary;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAboutDal : EfEntityBaseRepository<About,MyCVContext>,IAboutDal
    {
    }
}
