﻿

namespace GBCSporting2021_Team_AHJ.Models
{
    public class Registration
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
