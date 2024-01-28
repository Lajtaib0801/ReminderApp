using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lajtai_Benjamin_ReminderApp
{
    public class EventDatesDatabase
    {
        SQLiteAsyncConnection db;
        public EventDatesDatabase()
        {

        }

        async Task Init()
        {
            if (db is not null)
                return;
            db = new SQLiteAsyncConnection(Constants.EventsDatabasePath, Constants.Flags);
            await db.CreateTableAsync<SavedEvent>();
        }
        public async Task<List<SavedEvent>> GetEventsAsync()
        {
            Init();
            return db.Table<SavedEvent>().ToListAsync().Result;
        }
        public async Task<SavedEvent> GetEventByIdAsync(int id)
        {
            Init();
            return db.GetAsync<SavedEvent>(id).Result;
        }
        public async Task<int> SaveEventAsync(SavedEvent @event)
        {
            await Init();
            return await db.InsertAsync(@event);
        }
        public async Task<int> DeleteEventAsync(SavedEvent @event)
        {
            await Init();
            return await db.DeleteAsync(@event);
        }
        public async Task<int> UpdateEventAsync(SavedEvent @event)
        {
            await Init();
            return await db.UpdateAsync(@event);
        }
    }
}
