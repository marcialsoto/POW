using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UNFV.Portfolio.Models
{
    public class Enterprise
    {
        [Key]
        public int EnterpriseID { get; set; }

        [Required]
        [Display(Name = "Nombre de la Institucion")]
        public string Name { get; set; }

        [DataType(DataType.Url)]
        public string URL { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Logotipo")]
        public string Logo { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Education> Educations { get; set; }

        public virtual ICollection<Employment> Employments { get; set; }
    }
}