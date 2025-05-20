using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPlanner.Application.DTOs
{
    public class DayPlanDto
    {
        public string Day { get; set; } = string.Empty;
        public string Workout { get; set; } = string.Empty;
        public List<string> Meals { get; set; } = new List<string>();
        public List<string> HydrationTimes { get; set; } = new List<string>();
    }
}
