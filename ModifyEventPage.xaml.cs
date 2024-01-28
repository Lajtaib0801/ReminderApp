using Lajtai_Benjamin_ReminderApp.ViewModels;

namespace Lajtai_Benjamin_ReminderApp;

public partial class ModifyEventPage : ContentPage
{

    public ModifyEventPage(ModifyEventViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        ediDesc.IsEnabled = entName.IsEnabled = false;
        ediDesc.IsEnabled = entName.IsEnabled = true;
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}