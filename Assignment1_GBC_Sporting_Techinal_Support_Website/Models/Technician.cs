using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment1_GBC_Sporting_Techinal_Support_Website.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Please enter a valid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a valid Phone")]
        public string Phone { get; set; }


    }
}
