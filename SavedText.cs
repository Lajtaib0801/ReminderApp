using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lajtai_Benjamin_ReminderApp
{
    public class SavedText
    {
        [PrimaryKey]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }

        public SavedText(string text)
        {
            Text = text;
        }
        public SavedText(string text,int id)
        {
            Text = text;
            Id = id;
        }
        public SavedText()
        {
            
        }
    }
}
