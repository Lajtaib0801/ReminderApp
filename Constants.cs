using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lajtai_Benjamin_ReminderApp
{
    public static class Constants
    {
        public const string EventDatabaseFilename = "EventDatesDb.db3";
        public const string TextDatabaseFilename = "TextDb.db3";
        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;
        public static string EventsDatabasePath => Path.Combine(FileSystem.AppDataDirectory, EventDatabaseFilename);
        public static string TextDatabasePath => Path.Combine(FileSystem.AppDataDirectory, TextDatabaseFilename);
    }
}
