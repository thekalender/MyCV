using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Service : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(25, ErrorMessage = "Max 25 karekter olmalıdır.")]
        public string ServiceItem { get; set; }
        public string Image { get; set; }
    }
}
