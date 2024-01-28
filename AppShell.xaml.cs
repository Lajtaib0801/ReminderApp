namespace Lajtai_Benjamin_ReminderApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ModifyEventPage),typeof(ModifyEventPage));
            Routing.RegisterRoute(nameof(CreateEventPage),typeof(CreateEventPage));
        }
    }
}
