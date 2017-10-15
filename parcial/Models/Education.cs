using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UNFV.Portfolio.Models
{
    public class Education
    {
        [Key]
        public int EducationID { get; set; }

        [Required]
        [Display(Name = "Carrera")]
        public string Career { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Inicio")]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fin")]
        public DateTime End { get; set; }

        public int DegreeID { get; set; }

        public virtual Degree Degree { get; set; }

        public int EnterpriseID { get; set; }

        public virtual Enterprise Enterprise { get; set; }
    }
}