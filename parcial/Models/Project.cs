using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UNFV.Portfolio.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        [Required]
        [Display(Name = "Nombre del Proyecto")]
        public string Name { get; set; }

        [Display(Name = "Descripcion del Proyecto")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string Thumbnail { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "URL del Proyecto")]
        public string URL { get; set; }

        // Relacion de uno a muchos con 
        public int SkillID { get; set; }

        public virtual Skill Skill { get; set; }

        public int EnterpriseID { get; set; }

        public virtual Enterprise Enterprise { get; set; }
    }
}