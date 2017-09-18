using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSchedule.Models;
using TrainingSchedule.DbManager;

namespace TrainingSchedule.VIewModels
{
    class ExercisesViewModel : INotifyPropertyChanged
    {

        List<ExerciseModel> exercisesList { get; set; }
        private WorkoutModel workoutModel { get; set; }
        private bool isEmpty { get; set; }

        public ExercisesViewModel(WorkoutModel workoutModel)
        {
            this.workoutModel = workoutModel;
            exercisesList = workoutModel.listOfExercises;
        }

        public string WorkoutTitle
        {
            get { return workoutModel.titleWorkout; }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            set
            {
                if (isEmpty != value)
                {
                    isEmpty = value;
                    OnPropertyChanged("IsEmpty");
                }
            }
        }

        public List<ExerciseModel> ExercisesList
        {
            get { return exercisesList; }
            set
            {
                if(exercisesList != value)
                {
                    exercisesList = value;
                    OnPropertyChanged("ExercisesList");
                }
            }
        }

        public async void OnAppearing(object sender, EventArgs e)
        {

            List<ExerciseModel> tmpList = new List<ExerciseModel>();           


            try
            {
                await App.ExerciseDatabase.CreateTable();
                foreach (var a in await App.ExerciseDatabase.GetItemsAsync())
                {
                    if (a.trainingId.StartsWith(Convert.ToString(workoutModel.trainingId)))
                    {
                        if(a.lastTrainingDate.Date == DateTime.Today.Date)
                        {
                            a.isDoneToday = true;
                        }
                        tmpList.Add(toDbModelConverter.Convert(a));
                    }                    
                }
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Oops, something wrong!", "We couldn't read data from dataBase, write to developer", "OK");
            }

            if (tmpList.Count == 0)
            {
                IsEmpty = true;
            }
            else
            {
                IsEmpty = false;
            }
            ExercisesList = tmpList;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
