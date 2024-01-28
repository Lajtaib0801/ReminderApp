using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lajtai_Benjamin_ReminderApp.ViewModels
{
    [QueryProperty(nameof(Id), "id")]
    public partial class ModifyEventViewModel : ObservableObject
    {
        EventDatesDatabase db = new();
        SavedEvent @event;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string description;
        [ObservableProperty]
        DateTime date;
        private string id;
        public string Id
        {
            get => id;
            set
            {
                SetProperty(ref id, value);
                @event = GetEvent(int.Parse(value));
                Name = @event.Name;
                Description = @event.Description;
                Date = @event.Date;
            }
        }
        public ModifyEventViewModel()
        {

        }


        private SavedEvent GetEvent(int id)
        {
            return db.GetEventByIdAsync(id).Result;
        }
        [ICommand]
        async Task SaveChanges()
        {
            if (String.IsNullOrWhiteSpace(Name))
            {
                await Shell.Current.DisplayAlert("Hiba!", "Az esemény nevét kötelező megadni!", "OK");
                return;
            }
            @event.Name = Name;
            @event.Description = Description;
            @event.Date = Date;
            await db.UpdateEventAsync(@event);
            await Shell.Current.DisplayAlert("Siker", "Az esemény adatainak módosítása sikeres!", "OK");
            return;
        }
    }
}
