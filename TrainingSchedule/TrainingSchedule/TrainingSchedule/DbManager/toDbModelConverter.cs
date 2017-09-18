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
            outputModel.lastTrainingDate = inputModel.lastTrainingDate;

            return outputModel;
        }

        public static ExerciseModel Convert(DbExerciseModel inputModel)
        {
            ExerciseModel outputModel = new ExerciseModel();
            outputModel.titleExcercice = inputModel.Title;
            outputModel.trainingId = inputModel.trainingId;
            outputModel.lastTrainingDate = inputModel.lastTrainingDate;
            outputModel.isDoneToday = inputModel.isDoneToday;
            outputModel.amountOfSets = inputModel.amountOfSets;
           

            return outputModel;
        }

        public static SetModel Convert(DbSetModel inputModel)
        {
            SetModel outputModel = new SetModel();
            outputModel.trainingData = inputModel.trainingData;
            outputModel.setDate = inputModel.Date;
            outputModel.comment = inputModel.comment;

            return outputModel;
        }
    }
}
