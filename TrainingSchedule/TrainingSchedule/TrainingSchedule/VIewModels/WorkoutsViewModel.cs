using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSchedule.Models;

namespace TrainingSchedule.VIewModels
{
    class WorkoutsViewModel : INotifyPropertyChanged
    {
        List<WorkoutModel> workoutsList { get; set; }
        private bool isEmpty { get; set; }
        public WorkoutsViewModel()
        {
            workoutsList = new List<WorkoutModel>();            
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

        public List<WorkoutModel> WorkoutsList
        {
            get
            {
                return workoutsList;
            }
            set
            {
                if(workoutsList != value)
                {
                    workoutsList = value;
                    OnPropertyChanged("WorkoutsList");
                }
            }
        }

        public async void OnAppearing(object sender, EventArgs e)
        {          

            List<WorkoutModel> tmpList = new List<WorkoutModel>();
            tmpList.Add(new WorkoutModel() { titleWorkout = "Monday Workout", lastTrainingDate=DateTime.Today });
            tmpList.Add(new WorkoutModel() { titleWorkout = "Wednesday Workout", lastTrainingDate = DateTime.Today });
            tmpList.Add(new WorkoutModel() { titleWorkout = "Friday Workout", lastTrainingDate = DateTime.Today });
           

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
            WorkoutsList = tmpList;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
