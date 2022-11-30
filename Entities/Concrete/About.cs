using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class About : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AboutId { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Address { get; set; }
        public string Status { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Description { get; set; }
    }
}
