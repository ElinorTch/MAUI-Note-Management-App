using System.Diagnostics;

namespace MAUI_Note_Management_App.Views;

public partial class Note : ContentPage
{

    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "123.notes.txt");
    public Note()
    {
        InitializeComponent();
        Debug.WriteLine(_fileName);

        string appDataPath = FileSystem.AppDataDirectory;
        string sfileName = "123.notes.txt";
        ChargerNote(Path.Combine(appDataPath,sfileName));

        if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, TextEditor.Text);
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
        noteModel.Filename = fileName;
        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }
        BindingContext = noteModel;
    }

}