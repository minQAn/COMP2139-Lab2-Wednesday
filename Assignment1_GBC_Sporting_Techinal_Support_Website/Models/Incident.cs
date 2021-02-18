using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment1_GBC_Sporting_Techinal_Support_Website.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Please enter a valid Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a valid Description")]
        public string Description { get; set; }


        public int? TechnicianId { get; set; }      //nullable
        public Technician Technician { get; set; }


        public DateTime DateOpened { get; set; }
        [Required(ErrorMessage = "Please enter a valid Date Closed")]
        public DateTime DateClosed { get; set; }


    }
}
