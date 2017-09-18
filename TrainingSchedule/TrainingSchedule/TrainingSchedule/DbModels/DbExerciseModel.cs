using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrainingSchedule.DbModels
{
    [Table("Exercise")]
    public class DbExerciseModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        
        public bool isDoneToday { get; set; }
        public int amountOfSets { get; set; }
        public DateTime lastTrainingDate { get; set; }
        public string trainingId { get; set; }
        public string Title { get; set; }         
    }
}
