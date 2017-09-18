using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrainingSchedule.DbModels
{
    [Table("Sets")]
    public class DbSetModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string comment { get; set; }
        public string trainingId { get; set; }
        public string trainingData { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
