using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSchedule.Models;

namespace TrainingSchedule.Models
{
    public class ExerciseModel
    {
        public List<SetModel> listOfSets { get; set; }
        public int amountOfSets { get; set; }
        //public string comment { get; set; }
        public bool isDoneToday { get; set; }
        public DateTime lastTrainingDate { get; set; }
        public string trainingId { get; set; }
        public string titleExcercice { get; set; }
    }
}
