using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UNFV.Portfolio.Models
{
    public class Employment
    {
        [Key]
        public int EmploymentID { get; set; }

        [Required]
        [Display(Name = "Nombre del Puesto")]
        public string Title { get; set; }

        [Display(Name = "Descripcion del Puesto")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Inicio")]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fin")]
        public DateTime End { get; set; }

        public int EnterpriseID { get; set; }

        public virtual Enterprise Enterprise { get; set; }
    }
}