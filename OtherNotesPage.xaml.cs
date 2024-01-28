using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Lajtai_Benjamin_ReminderApp;

public partial class OtherNotesPage : ContentPage
{
	TextDatabase db;
	ObservableCollection<SavedText> savedTexts;
	SavedText text = new();
	public OtherNotesPage()
	{
		InitializeComponent();
		db = new();
		savedTexts = new();
		Load();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		Load();
    }
    private void Load()
	{
		savedTexts = new ObservableCollection<SavedText>(db.GetTextAsync().Result);
		if (savedTexts.Count == 0) 
			ediNotes.Text = "";
		else 
			ediNotes.Text = savedTexts.FirstOrDefault().Text;
	}

    private async void btnSaveText_Clicked(object sender, EventArgs e)
    {
		text.Id = 1;
		text.Text = ediNotes.Text;
		await db.SaveTextAsync(text);
		ediNotes.IsEnabled = false;
		ediNotes.IsEnabled = true;
		await Shell.Current.DisplayAlert("Siker!", "Szöveg elmentve", "OK");
    }

    private async void btnDeleteText_Clicked(object sender, EventArgs e)
    {
		if (await Shell.Current.DisplayAlert("Törlés?", "Biztosan törölni kívánja a szöveget?", "Igen", "Nem"))
		{
			text.Text = ediNotes.Text;
			text.Id = 1;
			await db.DeleteTextAsync(text);
			Load();
		}
    }
}