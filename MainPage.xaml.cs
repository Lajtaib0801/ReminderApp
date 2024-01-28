using Microsoft.Extensions.Logging;
using Plugin.Maui.Calendar.Models;
using System.Globalization;

namespace Lajtai_Benjamin_ReminderApp
{
    public partial class MainPage : ContentPage
    {
        public CultureInfo Culture => new CultureInfo("hu-HU");
        public EventCollection Events { get; set; }
        EventDatesDatabase db;
        public MainPage()
        {
            InitializeComponent();
            db = new();
            List<SavedEvent> eventsDb = db.GetEventsAsync().Result;
            if (eventsDb.Count() != 0)
                GetEvents(eventsDb);
            else
            {
                Events = new EventCollection();
            }
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Load();
        }
        private void Load()
        {
            List<SavedEvent> eventsDb = db.GetEventsAsync().Result;
            if (eventsDb.Count() != 0)
            {
                GetEvents(eventsDb);
                calendar.Events = Events;
            }
            else
            {
                Events = new EventCollection();
            }
        }
        private void GetEvents(List<SavedEvent> eventsDb)
        {
            Events = new EventCollection();
            Dictionary<DateTime, List<EventModel>> events = new();
            foreach (var @event in eventsDb)
            {
                if (!events.ContainsKey(@event.Date))
                    events.Add(@event.Date, new List<EventModel>() { new EventModel { Name = @event.Name, Description = @event.Description } });
                else
                    events[@event.Date].Add(new EventModel { Name = @event.Name, Description = @event.Description });
            }
            foreach (var @event in events)
            {
                Events.Add(@event.Key, @event.Value);
            }
        }
    }
    public class EventModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
