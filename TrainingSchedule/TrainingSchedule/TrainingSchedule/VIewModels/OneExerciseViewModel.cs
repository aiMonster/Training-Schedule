﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrainingSchedule.DbManager;
using TrainingSchedule.Models;
using TrainingSchedule.DbModels;
using Xamarin.Forms;

namespace TrainingSchedule.VIewModels
{
    class OneExerciseViewModel : INotifyPropertyChanged
    {
        public ICommand AddCommand { get; set; }
        List<SetModel> setsList { get; set; }
        List<RepsKgsModel> repsKgsList { get; set; }
        private string comment { get; set; }
        
        private ExerciseModel exerciseModel { get; set; }
        private bool isEmpty { get; set; }

        public OneExerciseViewModel(ExerciseModel exerciseModel)
        {
            this.AddCommand = new Command(Add);
            this.exerciseModel = exerciseModel;
            setsList = exerciseModel.listOfSets;
            repsKgsList = new List<RepsKgsModel>();
            for(int i = 0; i < exerciseModel.amountOfSets; i++)
            {
                repsKgsList.Add(new RepsKgsModel());

            }            
        }

        public string ExerciseTitle
        {
            get { return exerciseModel.titleExcercice; }
        }




        public string Comment
        {
            get { return comment; }
            set
            {
                if (comment != value)
                {
                    comment = value;
                    OnPropertyChanged("Comment");
                }
            }
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

            DbSetModel setModel = new DbSetModel();
            setModel.Date = DateTime.Now;
            setModel.comment = comment;
            string trainingData = "";
            foreach(var a in repsKgsList)
            {
                trainingData += "| " + a.Reps + "*" + a.Kgs + " |";
            }
            //setModel.trainingData = "3*23 | 13*0 | 12*2";
            string[] ids = exerciseModel.trainingId.Split('_');
            setModel.trainingData = trainingData;
            setModel.trainingId = exerciseModel.trainingId;

            try
            {
                await App.SetDatabase.SaveItemAsync(setModel);
                //changing data in workout
                DbWorkoutModel tmpWorkModel = new DbWorkoutModel();
                await App.WorkoutDatabase.CreateTable();
                foreach (var a in await App.WorkoutDatabase.GetItemsAsync())
                {
                    if(a.Id == Convert.ToInt32(ids[0]))
                    {
                        tmpWorkModel = a;
                        break;
                    }
                }
                tmpWorkModel.lastTrainingDate = DateTime.Now;
                await App.WorkoutDatabase.SaveItemAsync(tmpWorkModel);

                //changing data in exercise
                DbExerciseModel tmpExModel = new DbExerciseModel();
                tmpExModel.trainingId = exerciseModel.trainingId;
                tmpExModel.Title = exerciseModel.titleExcercice;
                tmpExModel.Id = Convert.ToInt32(ids[1]);
                tmpExModel.lastTrainingDate = DateTime.Now;
                tmpExModel.amountOfSets = exerciseModel.amountOfSets;
                //tmpExModel.comment = exerciseModel.comment;
                await App.ExerciseDatabase.SaveItemAsync(tmpExModel);

            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Oops, something wrong!", "We couldn't save expression to dataBase, write to developer", "OK");
            }

            OnAppearing(new object(), new EventArgs());




            //foreach(int a in repsArray)
            //{
            //    if(a <= 0)
            //    {
            //        await App.Current.MainPage.DisplayAlert("Oops!", "Impossible amount of repeats!", "OK");
            //        return;
            //    }
            //}
            //foreach(double a in kgsArray)
            //{
            //    if(a<=0)
            //    {
            //        await App.Current.MainPage.DisplayAlert("Oops!", "Impossible weight!", "OK");
            //        return;
            //    }
            //}
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

        

        public List<RepsKgsModel> RepsKgsList
        {
            get { return repsKgsList; }
            set
            {
                if (repsKgsList != value)
                {
                    repsKgsList = value;
                    OnPropertyChanged("RepsKgsList");
                }
            }
        }


        public async void OnAppearing(object sender, EventArgs e)
        {

            List<SetModel> tmpList = new List<SetModel>();
            try
            {
                await App.SetDatabase.CreateTable();
                foreach (var a in await App.SetDatabase.GetItemsAsync())
                {
                    if(a.trainingId.StartsWith(exerciseModel.trainingId))
                    {
                        tmpList.Insert(0, toDbModelConverter.Convert(a));
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
