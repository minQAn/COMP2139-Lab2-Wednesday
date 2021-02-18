using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment1_GBC_Sporting_Techinal_Support_Website.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter a valid First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a valid Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a valid Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a valid City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a valid State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a valid Postal Code")]
        public string PostalCode { get; set; }

        
        public string CountryId { get; set; }
        public Country Country { get; set; }


        public string Email { get; set; }

        public string Phone { get; set; }


        public string slug => FirstName?.Replace(' ', '-').ToLower()
            + '-' + LastName?.Replace(' ', '-').ToLower();


        // for many to mnay relation ship in Registration
        public virtual ICollection<Registration> Registrations { get; set; }

    }
}
