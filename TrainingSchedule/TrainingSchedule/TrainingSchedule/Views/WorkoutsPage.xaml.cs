using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TrainingSchedule.VIewModels;
using TrainingSchedule.Views;
using TrainingSchedule.Models;

namespace TrainingSchedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutsPage : ContentPage
    {
        public WorkoutsPage()
        {
            WorkoutsViewModel wm = new WorkoutsViewModel();
            base.Appearing += (o, e) => wm.OnAppearing(o, e);
            BindingContext = wm;
            InitializeComponent();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                WorkoutModel model = (WorkoutModel)e.SelectedItem;
                ((ListView)sender).SelectedItem = null;
                await Navigation.PushModalAsync(new ExercisesPage(model));
            }

        }
    }
}