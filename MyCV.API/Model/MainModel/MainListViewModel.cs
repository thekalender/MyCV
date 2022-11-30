using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.API.Model.MainModel
{
    public class MainListViewModel
    {
        public List<About> Abouts{ get; set; }
        public List<Service> Services { get; set; }
        public List<ClmOneExperince> ClmOneExperinces { get; set; }
        public List<ClmTwoExperince> ClmTwoExperinces { get; set; }
        public List<ClmOneSkill> ClmOneSkills { get; set; }
        public List<ClmTwoSkill> ClmTwoSkills { get; set; }
    }
}
