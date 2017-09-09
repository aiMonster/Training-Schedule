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
        public string Id { get; set; }

        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
