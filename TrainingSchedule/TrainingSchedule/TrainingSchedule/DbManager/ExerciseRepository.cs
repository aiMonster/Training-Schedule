using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using TrainingSchedule.DbModels;

namespace TrainingSchedule.DbManager
{
    public class ExerciseRepository
    {
        SQLiteAsyncConnection database;

        public ExerciseRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<DbExerciseModel>();
        }

        public async Task<List<DbExerciseModel>> GetItemsAsync()
        {
            return await database.Table<DbExerciseModel>().ToListAsync();

        }
        public async Task<DbExerciseModel> GetItemAsync(int id)
        {
            return await database.GetAsync<DbExerciseModel>(id);
        }
        public async Task<int> DeleteItemAsync(DbExerciseModel item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(DbExerciseModel item)
        {
            if (item.Id != 0)
            {
                await database.UpdateAsync(item);
                return item.Id;
            }
            else
            {
                await database.InsertAsync(item);
                return item.Id;
                              
            }
        }
    }
}
