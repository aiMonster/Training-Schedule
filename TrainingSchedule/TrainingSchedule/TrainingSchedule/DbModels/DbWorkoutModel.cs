using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrainingSchedule.DbModels
{
    [Table("Workout")]
    public class DbWorkoutModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string trainingId { get; set; }
        public DateTime lastTrainingDate { get; set; }
        public string Title { get; set; }
    }
}
