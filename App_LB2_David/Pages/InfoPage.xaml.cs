using System.Collections.ObjectModel;

namespace App_LB2_David.Pages;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();

        this.BindingContext = new MyViewModel();
	}

    async void GoBackToMainPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage"); //if the page you want to go back is not located in the same folder, just use "//" to go back on the hierarchy
    }
}

public class Page
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}

class MyViewModel
{
    public ObservableCollection<Page> Pages { get; set; }

    public MyViewModel()
    {
        Pages = new ObservableCollection<Page>();
        Pages.Add(new Page
        {
            Name = "Startseite",
            ImageUrl = "info_page_image_1.png",
            Description = "Dies ist die erste Seite die sie beim aufstarten der App sehen."
        });

        Pages.Add(new Page
        {
            Name = "Startseite (Eingabefeld und Oberthemen)",
            ImageUrl = "info_page_image_2.png",
            Description = "Bei der Startseite können sie ihre Frage direkt beim Eingabefeld eingeben oder sie können ihre Frage bei den Oberthemen aussuchen"
        });

        Pages.Add(new Page
        {
            Name = "Beispiel: Frageseite mit Antwort",
            ImageUrl = "info_page_image_3.png",
            Description = "Hier sehen sie einer der Frageseiten die zur verfügung stehen. Alle seiten sehen identisch aus. Das eizige das sich unterscheidet ist der Inhalt."
        });

        Pages.Add(new Page
        {
            Name = "Kommentare",
            ImageUrl = "info_page_image_4.png",
            Description = "Auch bei dieser App kann man Kommentare hinterlassen. Ganz Unten sehen sie jeweils die Kommentare von anderen und ihr eigenes (welches dann eine dünklere Farbe hat). Bei der Eingabe können sie ihr Kommentar schreiben und dabei eine Bewertung hinterlassen (von 1-5 Sterne)"
        });
    }
}