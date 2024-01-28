using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Lajtai_Benjamin_ReminderApp
{
    public class SavedEvent
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public SavedEvent(DateTime date, string name, string description)
        {
            Date = date;
            Name = name;
            Description = description;
        }
        public SavedEvent()
        {
            
        }
    }
}
