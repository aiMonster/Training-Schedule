using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSchedule.Models;

namespace TrainingSchedule.VIewModels
{
    class OneExerciseViewModel : INotifyPropertyChanged
    {
        List<SetModel> setsList { get; set; }
        private ExerciseModel exerciseModel { get; set; }
        private bool isEmpty { get; set; }

        public OneExerciseViewModel(ExerciseModel exerciseModel)
        {
            this.exerciseModel = exerciseModel;
            setsList = exerciseModel.listOfSets;
        }

        public string ExerciseTitle
        {
            get { return exerciseModel.titleExcercice; }
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

        public List<SetModel> SetsList
        {
            get { return setsList; }
            set
            {
                if (setsList != value)
                {
                    setsList = value;
                    OnPropertyChanged("SetsList");
                }
            }
        }

        public async void OnAppearing(object sender, EventArgs e)
        {

            List<SetModel> tmpList = new List<SetModel>();
            tmpList.Add(new SetModel() { trainingData = "2*8 - 7*9 - 3*2" });
            tmpList.Add(new SetModel() { trainingData = "2*9 - 4*23 - 31*12" });
            tmpList.Add(new SetModel() { trainingData = "2*9 - 7*9 - 3*12" });
            tmpList.Add(new SetModel() { trainingData = "2*6 - 7*29 - 3*12" });
            tmpList.Add(new SetModel() { trainingData = "2*4 - 7*19 - 3*2" });
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
            SetsList = tmpList;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
