using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TrainingSchedule.VIewModels;
using TrainingSchedule.Models;

namespace TrainingSchedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OneExercisePage : ContentPage
    {
        public OneExercisePage(ExerciseModel model)
        {
            OneExerciseViewModel om = new OneExerciseViewModel(model);
            base.Appearing += (o, e) => om.OnAppearing(o, e);
            BindingContext = om;
            InitializeComponent();
        }
    }
}