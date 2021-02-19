using System;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_Team_AHJ.Models
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
