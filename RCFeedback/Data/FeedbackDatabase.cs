using SQLite;
using System.Threading.Tasks;
using RCFeedback.Models;
using System;
using System.IO;

namespace RCFeedback.Data
{
    public class FeedbackDatabase
    {
        readonly SQLiteAsyncConnection database;

        public FeedbackDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Feedback>().Wait();
        }

        public Task<int> SaveItemAsync(Feedback item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public void CopyDatabaseToExternalStorage()
        {
            try
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "FeedbackDatabase.db3");
                var newFolderPath = "/storage/emulated/0/";
                var newDbPath = Path.Combine(newFolderPath, "FeedbackDatabase.db3");

                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }

                if (File.Exists(newDbPath))
                {
                    File.Delete(newDbPath);
                }

                File.Copy(dbPath, newDbPath);

                if (File.Exists(newDbPath))
                {
                    Console.WriteLine("Database copied to external storage successfully.");
                }
                else
                {
                    Console.WriteLine("Database copy to external storage failed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while copying database to external storage: " + ex.Message);
            }
        }
    }
}





