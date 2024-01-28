using CommunityToolkit.Mvvm.ComponentModel;
using Lajtai_Benjamin_ReminderApp.ViewModels;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace Lajtai_Benjamin_ReminderApp;

public partial class ManageEventPage : ContentPage
{
    EventDatesDatabase db;
    ObservableCollection<SavedEvent> events;

    public ManageEventPage()
    {
        InitializeComponent();
        db = new();
        events = new();
        Load();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Load();
    }
    public void Load()
    {
        events = new ObservableCollection<SavedEvent>(db.GetEventsAsync().Result.OrderBy(x => x.Date));
        lsvEvents.ItemsSource = events;
    }
    public async void GoToModifyPage(object sender, TappedEventArgs e)
    {
        string id = (sender as Label).ClassId;
        await Shell.Current.GoToAsync($"{nameof(ModifyEventPage)}?id={id}");
    }
    async void RemoveEvent(object sender, TappedEventArgs e)
    {
        SavedEvent @event = events.Where(x => x.Id == int.Parse((sender as Label).ClassId)).FirstOrDefault();
        if (@event is not null)
        {
            if (await App.Current.MainPage.DisplayAlert("Törlés?", "Biztosan törölni kívánja a kijelölt eseményt?", "Igen", "Mégsem"))
            {
                events.Remove(@event);
                await db.DeleteEventAsync(@event);
                Load();
            }
        }
    }

    private async void btnCreateEvent_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(CreateEventPage)}");
    }
}