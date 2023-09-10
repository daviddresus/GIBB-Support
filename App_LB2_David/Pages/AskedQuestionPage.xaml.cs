namespace App_LB2_David.Pages;

public partial class AskedQuestionPage : ContentPage
{
    public string UserInput { get; set; }

    public AskedQuestionPage()
    {
        InitializeComponent();
    }

    public AskedQuestionPage(string userInput)
    {
        InitializeComponent();
        UserInput = userInput;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        QuestionEntry.Text = UserInput;

        string userInputLower = UserInput.ToLowerInvariant();
        string[] WordsFromTheQuestion1_1 = { "vm", "aufstarten" };
        string[] WordsFromTheQuestion1_2 = { "ram", "cpu", "cores", "vm", "geben" };
        string[] WordsFromTheQuestion1_3 = { "neue", "vms", "vm", "herunterladen" };
        string[] WordsFromTheQuestion1_4 = { "funktioniert", "vm", "nicht" };
        string[] WordsFromTheQuestion2_1 = { "link", "finden", "website" };

        Button_1_1.IsVisible = WordsFromTheQuestion1_1.Any(x => userInputLower.Contains(x.ToLowerInvariant()));
        Button_1_2.IsVisible = WordsFromTheQuestion1_2.Any(x => userInputLower.Contains(x.ToLowerInvariant()));
        Button_1_3.IsVisible = WordsFromTheQuestion1_3.Any(x => userInputLower.Contains(x.ToLowerInvariant()));
        Button_1_4.IsVisible = WordsFromTheQuestion1_4.Any(x => userInputLower.Contains(x.ToLowerInvariant()));
        Button_2_1.IsVisible = WordsFromTheQuestion2_1.Any(x => userInputLower.Contains(x.ToLowerInvariant()));

        if (Enumerable.All(new[] { Button_1_1, Button_1_2, Button_1_3, Button_1_4, Button_2_1 }, x => !x.IsVisible))
        {
            // All buttons are not visible, there was no match
            NoMatchMessage.IsVisible = true;
        }
        else
        {
            NoMatchMessage.IsVisible = false;
        }
    }

    void ShowMatchingQuestions(object sender, EventArgs e)
    {
        UserInput = QuestionEntry.Text;

        string userInputLower = UserInput.ToLowerInvariant();
        string[] WordsFromTheQuestion1_1 = { "vm", "aufstarten" };
        string[] WordsFromTheQuestion1_2 = { "ram", "cpu", "cores", "vm", "geben" };
        string[] WordsFromTheQuestion1_3 = { "neue", "vms", "vm", "herunterladen" };
        string[] WordsFromTheQuestion1_4 = { "funktioniert", "vm", "nicht" };
        string[] WordsFromTheQuestion2_1 = { "link", "finden", "website" };

        Button_1_1.IsVisible = WordsFromTheQuestion1_1.Any(x => userInputLower.Contains(x.ToLowerInvariant()));
        Button_1_2.IsVisible = WordsFromTheQuestion1_2.Any(x => userInputLower.Contains(x.ToLowerInvariant()));
        Button_1_3.IsVisible = WordsFromTheQuestion1_3.Any(x => userInputLower.Contains(x.ToLowerInvariant()));
        Button_1_4.IsVisible = WordsFromTheQuestion1_4.Any(x => userInputLower.Contains(x.ToLowerInvariant()));
        Button_2_1.IsVisible = WordsFromTheQuestion2_1.Any(x => userInputLower.Contains(x.ToLowerInvariant()));

        if (Enumerable.All(new[] { Button_1_1, Button_1_2, Button_1_3, Button_1_4, Button_2_1 }, x => !x.IsVisible))
        {
            // All buttons are not visible, there was no match
            NoMatchMessage.IsVisible = true;
        }
        else
        {
            NoMatchMessage.IsVisible = false;
        }
    }



    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = QuestionEntry.Text;

        System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(QuestionEntry.Text, @"^[0-9a-z A-Z,.-]+$");

        if (match.Success)
        {
            QuestionEntry.TextColor = Colors.Green;
        }
        else
        {
            QuestionEntry.TextColor = Colors.Red;
        }
    }

    Button lastButton = null;
    Color lastTextColor = Colors.White;
    Color lastBackgroundColor = Colors.Blue;

    private async void Button_Pressed(object sender, EventArgs e)
    {
        // Save the current button and its colors
        Button currentButton = sender as Button;
        Color currentTextColor = currentButton.TextColor;
        Color currentBackgroundColor = currentButton.BackgroundColor;

        // If the current button is not the same as the last button, set the colors of the last button back to their original values
        if (currentButton != lastButton)
        {
            if (lastButton != null)
            {
                lastButton.TextColor = lastTextColor;
                lastButton.BackgroundColor = lastBackgroundColor;
            }

            // Save the current button and its colors as the last button and its original colors
            lastButton = currentButton;
            lastTextColor = currentTextColor;
            lastBackgroundColor = currentBackgroundColor;
        }

        // Swap the text color and background color of the current button
        currentButton.TextColor = currentBackgroundColor;
        currentButton.BackgroundColor = currentTextColor;

        // Wait for 0.5 seconds
        await Task.Delay(500);

        // Set the colors of the current button back to their original values
        currentButton.TextColor = currentTextColor;
        currentButton.BackgroundColor = currentBackgroundColor;
    }

    void OnEntryCompleted(object sender, EventArgs e)
    {
        string text = ((Entry)sender).Text;
    }

    private async void Question_Clicked_1_1(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Q1_1");
    }

    private async void Question_Clicked_1_2(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Q1_2");
    }

    private async void Question_Clicked_1_3(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Q1_3");
    }

    private async void Question_Clicked_1_4(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Q1_4");
    }

    private async void Question_Clicked_2_1(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Q2_1");
    }

    async void GoBackToMainPage(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("//MainPage"); //if the page you want to go back is not located in the same folder, just use "//" to go back on the hierarchy
    }
}