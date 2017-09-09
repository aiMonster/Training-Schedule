using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TrainingSchedule.VIewModels;

namespace TrainingSchedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddWorkoutPage : ContentPage
    {
        public AddWorkoutPage()
        {
            InitializeComponent();
            AddWorkoutViewModel wm = new AddWorkoutViewModel();
            wm.Navigation = Navigation;
            BindingContext = wm;
        }
    }
}