using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(600, ErrorMessage = "Max 600 karekter olmalıdır.")]
        public string Message { get; set; }
    }
}
