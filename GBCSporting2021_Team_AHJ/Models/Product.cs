using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GBCSporting2021_Team_AHJ.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a valid Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter a valid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a valid Price")]
        public double Price { get; set; }

        public DateTime ReleaseDate { get; set; }


        // for many to many relationship in Registration
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
