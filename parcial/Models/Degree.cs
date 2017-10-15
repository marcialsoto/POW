using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UNFV.Portfolio.Models
{
    public class Degree
    {
        [Key]
        public int DegreeID { get; set; }

        [Required]
        [Display(Name = "Grado")]
        public string Name { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
    }
}