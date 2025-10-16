using System.Collections.ObjectModel;

namespace MAUI_Note_Management_App.Models
{
    public class CListeNotes
    {

        public CListeNotes() => ChargerNotes();

        public ObservableCollection<CNote> CollNotes { get; set; } = new ObservableCollection<CNote>();

        public void ChargerNotes ()
        {
            string dir = FileSystem.AppDataDirectory;
            IEnumerable<CNote> listenotes = Directory.EnumerateFiles(dir, "*.notes.txt")
                .Select(file => new CNote
                {
                    Filename = Path.GetFileName(file),
                    Date = File.GetCreationTime(file),
                    Text = File.ReadAllText(file)
                })
                .OrderByDescending(note => note.Date);

            foreach (CNote note in listenotes)
            {
                CollNotes.Add(note);
            }
        }
    }
}