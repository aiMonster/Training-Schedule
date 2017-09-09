using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Xamarin.Forms;

using TrainingSchedule;
using TrainingSchedule.DbManager;
using TrainingSchedule.Droid;

[assembly: Dependency(typeof(SQLite_Android))]
namespace TrainingSchedule.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }

        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}