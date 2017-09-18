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
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public INavigation Navigation { get; set; }
        private List<DbExerciseModel> exerciseList { get; set; }
        private string mainTitle { get; set; }

        public AddWorkoutViewModel()
        {
            exerciseList = new List<DbExerciseModel>();
            exerciseList.Add(new DbExerciseModel());
            this.SaveCommand = new Command(Save);
            this.AddCommand = new Command(Add);
            this.RemoveCommand = new Command(Remove);
        }


        public void Add()
        {
            List<DbExerciseModel> tmpList = new List<DbExerciseModel>(exerciseList);
            tmpList.Add(new DbExerciseModel());
            ExerciseList = tmpList;

        }

        public async void Remove()
        {
            if(exerciseList.Count <=1 )
            {
                await App.Current.MainPage.DisplayAlert("Oops!", "Can't remove anymore rows!", "OK");
                return;
            }
            List<DbExerciseModel> tmpList = new List<DbExerciseModel>(exerciseList);
            tmpList.Remove(tmpList.Last());
            ExerciseList = tmpList;
        }


        public List<DbExerciseModel> ExerciseList
        {
            get { return exerciseList; }
            set
            {
                if(exerciseList != value)
                {
                    exerciseList = value;
                    OnPropertyChanged("ExerciseList");
                }
            }
        }



        public async void Save()
        {
            DbWorkoutModel model = new DbWorkoutModel();
            List<DbExerciseModel> exercises = new List<DbExerciseModel>();
            
            foreach(var a in exerciseList)
            {
                if(a.Title == "" || String.IsNullOrEmpty(a.Title))
                {
                    await App.Current.MainPage.DisplayAlert("Oops!", "You didn't fill all exercises!", "OK");
                    return;
                }
                exercises.Add(a);

            }

            model.Title = mainTitle;
           
            //saving to db
            try
            {              
               int id = await App.WorkoutDatabase.SaveItemAsync(model);  
                
                foreach(var a in exercises)
                {
                    
                    int tmpid = await App.ExerciseDatabase.SaveItemAsync(a);
                    a.trainingId = id + "_" + tmpid + "_";
                    await App.ExerciseDatabase.SaveItemAsync(a);

                }            
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
