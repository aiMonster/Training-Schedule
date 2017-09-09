using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrainingSchedule.Models;
using TrainingSchedule.DbModels;

namespace TrainingSchedule.DbManager
{
    public static class toDbModelConverter
    {
        public static WorkoutModel Convert(DbWorkoutModel inputModel)
        {
            WorkoutModel outputModel = new WorkoutModel();
            outputModel.titleWorkout = inputModel.Title;
            outputModel.trainingId = inputModel.trainingId;

            return outputModel;

        }
    }
}
