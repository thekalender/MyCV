using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class ClmTwoSkill : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(20, ErrorMessage = "Max 20 karekter olmalıdır.")]
        public string SkillItem { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int SkillValue { get; set; }
    }
}
