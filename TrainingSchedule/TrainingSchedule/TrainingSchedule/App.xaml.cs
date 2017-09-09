using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingSchedule.DbManager;
using TrainingSchedule.Views;

using Xamarin.Forms;

namespace TrainingSchedule
{
    public partial class App : Application
    {
        public const string WORKOUT_DATABASE_NAME = "trainings.db";
        public static WorkoutRepository workoutDatabase;
        public static WorkoutRepository WorkoutDatabase
        {
            get
            {
                if (workoutDatabase == null)
                {
                    workoutDatabase = new WorkoutRepository(WORKOUT_DATABASE_NAME);
                }
                return workoutDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new TrainingSchedule.Views.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
