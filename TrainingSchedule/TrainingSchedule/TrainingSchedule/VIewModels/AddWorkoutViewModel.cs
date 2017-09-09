using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using TrainingSchedule.DbModels;

namespace TrainingSchedule.VIewModels
{
    public  class AddWorkoutViewModel : INotifyPropertyChanged
    {
        public ICommand SaveCommand { get; set; }
        public INavigation Navigation { get; set; }
        private string mainTitle { get; set; }

        public AddWorkoutViewModel()
        {
            this.SaveCommand = new Command(Save);
        }


        public async void Save()
        {
            DbWorkoutModel model = new DbWorkoutModel();
            model.Title = mainTitle;

            //saving to db
            try
            {
               int id =  await App.WorkoutDatabase.SaveItemAsync(model);
               model.Id = id;
               model.trainingId = id + "_";
                await App.WorkoutDatabase.SaveItemAsync(model);


            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Oops, something wrong!", "We couldn't save expression to dataBase, write to developer", "OK");
            }


            await Navigation.PopModalAsync();
        }


        public string MainTitle
        {
            get { return mainTitle; }
            set
            {
                if(mainTitle != value)
                {
                    mainTitle = value;
                    OnPropertyChanged("MainTitle");
                }
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
