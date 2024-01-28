using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lajtai_Benjamin_ReminderApp
{
    public class TextDatabase
    {
        SQLiteAsyncConnection textDb;
        public TextDatabase()
        {

        }
        async Task Init()
        {
            if (textDb is not null)
                return;
            textDb = new SQLiteAsyncConnection(Constants.TextDatabasePath, Constants.Flags);
            await textDb.CreateTableAsync<SavedText>();
        }
        public async Task<List<SavedText>> GetTextAsync()
        {
            Init();
            return textDb.Table<SavedText>().ToListAsync().Result;
        }
        public async Task<int> SaveTextAsync(SavedText text)
        {
            await Init();
            int getText = GetTextAsync().Result.Count();
            if (getText == 0)
            {
                text.Id = 1;
                return await textDb.InsertAsync(text);
            }
            else
            {
                text.Id = 1;
                return await textDb.UpdateAsync(text);
            }
        }
        public async Task<int> DeleteTextAsync(SavedText text)
        {
            await Init();
            if (GetTextAsync().Result.Count() == 0)
                return await textDb.InsertAsync(new SavedText("", 1));
            else
            {
                await textDb.DeleteAsync(text);
                return await textDb.InsertAsync(new SavedText("", 1));
            }
        }
    }
}
