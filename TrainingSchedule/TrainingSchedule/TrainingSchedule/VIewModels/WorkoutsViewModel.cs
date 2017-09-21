using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSchedule.Models;
using TrainingSchedule.DbManager;
using System.Windows.Input;
using Xamarin.Forms;
using TrainingSchedule.Views;

namespace TrainingSchedule.VIewModels
{
    class WorkoutsViewModel : INotifyPropertyChanged
    {
        public ICommand AddCommand { get; set; } //to add new workout        
        public INavigation Navigation { get; set; }
        List<WorkoutModel> workoutsList { get; set; }
        private bool isEmpty { get; set; }

        public WorkoutsViewModel()
        {
            this.AddCommand = new Command(Add);            
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

        public async void Add()
        {
            await Navigation.PushModalAsync(new AddWorkoutPage());
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

            try
            {
                await App.WorkoutDatabase.CreateTable();
                foreach (var a in await App.WorkoutDatabase.GetItemsAsync())
                {
                    a.trainingId = a.Id + "_";
                    tmpList.Insert(0, toDbModelConverter.Convert(a));
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
