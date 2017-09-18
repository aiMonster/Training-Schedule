using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSchedule.DbModels;
using Xamarin.Forms;

namespace TrainingSchedule.DbManager
{
    public class SetRepository
    {
        SQLiteAsyncConnection database;

        public SetRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<DbSetModel>();
        }

        public async Task<List<DbSetModel>> GetItemsAsync()
        {
            return await database.Table<DbSetModel>().ToListAsync();

        }
        public async Task<DbSetModel> GetItemAsync(int id)
        {
            return await database.GetAsync<DbSetModel>(id);
        }
        public async Task<int> DeleteItemAsync(DbSetModel item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(DbSetModel item)
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
