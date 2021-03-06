﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TrainingSchedule.Models;
using TrainingSchedule.VIewModels;
using TrainingSchedule.Views;

namespace TrainingSchedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisesPage : ContentPage
    {
        public ExercisesPage(WorkoutModel model)
        {
            ExercisesViewModel em = new ExercisesViewModel(model);
            em.Navigation = Navigation;
            base.Appearing += (o, e) => em.OnAppearing(o, e);
            BindingContext = em;            
            InitializeComponent();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ExerciseModel model = (ExerciseModel)e.SelectedItem;
                ((ListView)sender).SelectedItem = null;                
                await Navigation.PushModalAsync(new OneExercisePage(model));
            }

        }
    }
}