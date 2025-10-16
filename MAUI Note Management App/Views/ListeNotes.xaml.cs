namespace MAUI_Note_Management_App.Views;

public partial class ListeNotes : ContentPage
{
	public ListeNotes()
	{
		InitializeComponent();
        Routing.RegisterRoute($"{nameof(Note)}", typeof(Note));
        BindingContext = new Models.CListeNotes();
    }

    private async void Ajouter_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Note));
    }
}