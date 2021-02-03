using System;

using System.ComponentModel.DataAnnotations;

namespace Lab3_wk4.Models
{
    public class Contact
    {
        //Primary key
        public int ContactId { get; set; }

        //Entities
        [Required(ErrorMessage = "Please enter a valid firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a valid lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a valid phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        public string Organization { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 10, ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }

        public Category Category{get;set;}

        public string slug => FirstName?.Replace(' ', '-').ToLower()
            + '-' + LastName?.Replace(' ', '-').ToLower();


    }
}
