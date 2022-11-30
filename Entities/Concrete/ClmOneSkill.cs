using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class ClmOneSkill : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }

        [Required(ErrorMessage ="Bu alan zorunludur.")]
        [MaxLength(20,ErrorMessage ="Max 20 karekter olmalıdır.")]
        public string SkillItem { get; set; }

        [Required]
        [Range(0,100,ErrorMessage ="0 ile 100 arasında bir değer olmalıdır.")]
        public int SkillValue { get; set; }
    }
}
