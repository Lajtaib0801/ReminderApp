namespace Lajtai_Benjamin_ReminderApp;

public partial class CreateEventPage : ContentPage
{
    EventDatesDatabase db = new();
    public CreateEventPage()
    {
        InitializeComponent();
    }

    private async void btnAddEvent_Clicked(object sender, EventArgs e)
    {
        if (!String.IsNullOrWhiteSpace(entEventName.Text))
        {
            await db.SaveEventAsync(new SavedEvent(dpDate.Date, entEventName.Text, ediDescription.Text));
            entEventName.Text = ediDescription.Text = String.Empty;
            await DisplayAlert("Siker", "Az esemény hozzáadása sikeres!", "OK");
            await Navigation.PopAsync();
        }
        else
            await DisplayAlert("Hiba", "Az esemény nevét kötelezõ megadni!", "OK");
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}