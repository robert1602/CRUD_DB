using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUD_DB.Models
{
    public class StudentModel
    {
        public int IdStudent { get; set; }

        [Display(Name="Nombre")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress(ErrorMessage = "Email no valido")]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [Required]        
        public string Address { get; set; }


    }
}