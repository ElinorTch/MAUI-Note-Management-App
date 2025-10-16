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

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = new Models.CListeNotes();
    }

    private async void CollectionDeNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            var note = e.CurrentSelection.FirstOrDefault() as Models.CNote;
            await Shell.Current.GoToAsync($"{nameof(Note)}?{nameof(Note.ItemId)}={note.Filename}");
        }
        CollectionDeNotes.SelectedItem = null;

    }
}