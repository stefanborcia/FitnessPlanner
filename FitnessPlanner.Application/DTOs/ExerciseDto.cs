using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPlanner.Application.DTOs
{
    public class ExerciseDto
    {
        public string Name { get; set; } = string.Empty;
        public int Reps { get; set; }
        public int Sets { get; set; }
    }
}
