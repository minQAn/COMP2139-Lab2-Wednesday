using System;
using System.ComponentModel.DataAnnotations;


namespace GBCSporting2021_Team_AHJ.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }

        [Required(ErrorMessage = "Please select a customer.")]
        public int CustomerId { get; set; }        
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Please select a product.")]
        public int ProductId { get; set; }       
        public Product Product { get; set; }

        [Required(ErrorMessage = "Please enter a valid Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a valid Description")]
        public string Description { get; set; }


        public int? TechnicianId { get; set; }      //nullable
        public Technician Technician { get; set; }


        public DateTime DateOpened { get; set; }
        public DateTime DateClosed { get; set; }

    }
}
