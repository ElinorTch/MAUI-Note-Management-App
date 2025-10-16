using System.Diagnostics;
using System.IO.Enumeration;

namespace MAUI_Note_Management_App.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class Note : ContentPage
{
    static string fileName = $"{Path.GetRandomFileName()}.notes.txt";
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, fileName);

    public string ItemId
    {
        set { ChargerNote(value); }
    }

    public Note()
    {
        InitializeComponent();
        Debug.WriteLine(_fileName);

        string appDataPath = FileSystem.AppDataDirectory;
        string sfileName = fileName;
        ChargerNote(Path.Combine(appDataPath,sfileName));
        if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.CNote note)
            File.WriteAllText(note.Filename, TextEditor.Text);
        await Shell.Current.GoToAsync("..");
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
            File.Delete(_fileName);
        TextEditor.Text = string.Empty;
    }


    private void ChargerNote(string fileName)
    {
        Models.CNote noteModel = new Models.CNote();
        string appDataPath = FileSystem.AppDataDirectory;
        noteModel.Filename = Path.Combine(appDataPath, fileName);
        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }
        BindingContext = noteModel;
    }

}