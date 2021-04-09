using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Team_AHJ.Models
{
    public class TechnicianIncidentViewModel
    {
        [Required(ErrorMessage = "You must select a technician.")]
        public int TechnicianID { get; set; }
        public List<Technician> Technicians { get; set; }
        
    }
}
