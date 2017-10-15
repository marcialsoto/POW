using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UNFV.Portfolio.Models
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }

        [Required]
        [DisplayName("Habilidad")]
        public string Name { get; set; }

        [DisplayName("Descripción")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Porcentaje")]
        public string Percentage { get; set; }

        [Required]
        [DisplayName("Icono")]
        public string Icon { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}