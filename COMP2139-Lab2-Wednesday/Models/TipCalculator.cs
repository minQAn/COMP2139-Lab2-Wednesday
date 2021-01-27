//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace COMP2139_Lab2_Wednesday.Models
{
    public class TipCalculator
    {
        // tool-> nugetPakage -> solution 에서 dataAn 을 다운받아서 설치해야지 이 라이브러리를 사용가능
        [Required(ErrorMessage="Please enter a value for the cost of the meal.")] 
        [Range(0.0, 10000.0, ErrorMessage = "Please enter a value greater than zero")]
        public double? MealCost { get; set; } //nullable, accessor mutator? 

        public double CalculateTip(double precent)
        {
            if (MealCost.HasValue)
            {
                var tip = MealCost.Value * precent;
                return tip;
            }
            else
            {
                return 0;
            }
        }

    }
}
