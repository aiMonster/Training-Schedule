using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using TrainingSchedule.DbModels;

namespace TrainingSchedule.DbManager
{
    public class WorkoutRepository
    {
        SQLiteAsyncConnection database;

        public WorkoutRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteAsyncConnection(databasePath);            
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<DbWorkoutModel>();
        }
        
        public async Task<List<DbWorkoutModel>> GetItemsAsync()
        {
            return await database.Table<DbWorkoutModel>().ToListAsync();

        }
        public async Task<DbWorkoutModel> GetItemAsync(int id)
        {
            return await database.GetAsync<DbWorkoutModel>(id);
        }
        public async Task<int> DeleteItemAsync(DbWorkoutModel item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(DbWorkoutModel item)
        {
            if (item.Id != 0)
            {
                await database.UpdateAsync(item);
                return item.Id;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
    }
}
