using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSchedule.Models;

namespace TrainingSchedule.Models
{
    public class WorkoutModel
    {
        public List<ExerciseModel> listOfExercises {get; set;}
        public string titleWorkout { get; set; }
        public DateTime lastTrainingDate { get; set; }
    }
}
