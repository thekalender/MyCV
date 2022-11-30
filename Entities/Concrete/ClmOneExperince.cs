using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class ClmOneExperince : IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExperinceId { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(25, ErrorMessage = "Max 25 karekter olmalıdır.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string ExperinceDate { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(400, ErrorMessage = "Max 400 karekter olmalıdır.")]
        public string Description { get; set; }
    }
}
