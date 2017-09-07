using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSchedule.Models;

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
            tmpList.Add(new ExerciseModel() { titleExcercice = "sitting" });
            tmpList.Add(new ExerciseModel() { titleExcercice = "by legs" });
            //tmpList.Add(new WorkoutModel() { titleWorkout = "hello" });
            //tmpList.Add(new WorkoutModel() { titleWorkout = "hello2" });

            //try
            //{
            //    await App.Database.CreateTable();
            //    foreach (var a in await App.Database.GetItemsAsync())
            //    {
            //        tmpList.Insert(0, a);
            //    }
            //}
            //catch
            //{
            //    await App.Current.MainPage.DisplayAlert("Oops, something wrong!", "We couldn't read data from dataBase, write to developer", "OK");
            //}

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
