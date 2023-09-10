using App_LB2_David.Pages;
using Microsoft.Maui.Controls.Xaml.Internals;

namespace App_LB2_David;

public partial class MainPage : ContentPage
{
    private bool[] isExpanded = new bool[] { false, false, false }; //add another false if there is another Main Button

    public MainPage()
    {
        InitializeComponent();
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

    void DefineMinDate(object sender, EventArgs e)
    {
        UntilDate.MinimumDate = FromDate.Date;
    }

    void Display_Themes(object sender, EventArgs e)
    {
        if (ThemeSwitch.IsToggled == true)
        {
            Button_1.IsVisible = false;
            Button_2.IsVisible = false;
            Button_3.IsVisible = false;

            Button_1_1.IsVisible = true;
            Button_1_2.IsVisible = true;
            Button_1_3.IsVisible = true;
            Button_1_4.IsVisible = true;

            Button_2_1.IsVisible = true;
            Button_2_2.IsVisible = true;

            Button_3_1.IsVisible = true;
            Button_3_2.IsVisible = true;
        }
        else
        {
            Button_1.IsVisible = true;
            Button_2.IsVisible = true;
            Button_3.IsVisible = true;

            Button_1_1.IsVisible = false;
            Button_1_2.IsVisible = false;
            Button_1_3.IsVisible = false;
            Button_1_4.IsVisible = false;

            Button_2_1.IsVisible = false;
            Button_2_2.IsVisible = false;

            Button_3_1.IsVisible = false;
            Button_3_2.IsVisible = false;
        }
    }

    void DisplayOnlyMatchingDates(object sender, EventArgs e)
    {
        string creationDate_Q1_1 = "1/1/2023";
        string creationDate_Q1_2 = "1/1/2023";
        string creationDate_Q1_3 = "1/1/2023";
        string creationDate_Q1_4 = "2/1/2023";

        string creationDate_Q2_1 = "3/1/2023";

        DateTime fromdate = FromDate.Date;
        string fromdateString = fromdate.ToString("dd.mm.yyyy");

        DateTime untildate = UntilDate.Date;
        string untildateString = untildate.ToString("dd.mm.yyyy");

        DateTime date_Q1_1 = DateTime.Parse(creationDate_Q1_1);
        DateTime date_Q1_2 = DateTime.Parse(creationDate_Q1_2);
        DateTime date_Q1_3 = DateTime.Parse(creationDate_Q1_3);
        DateTime date_Q1_4 = DateTime.Parse(creationDate_Q1_4);

        DateTime date_Q2_1 = DateTime.Parse(creationDate_Q2_1);

        if (date_Q1_1.CompareTo(fromdate) >= 0 && date_Q1_1.CompareTo(untildate) <= 0)
        {
            // The date is between the start and end dates
            Button_1_1.IsVisible = true;
        }
        else
        {
            // The date is not between the start and end dates
            Button_1_1.IsVisible = false;
        }

        if (date_Q1_2.CompareTo(fromdate) >= 0 && date_Q1_2.CompareTo(untildate) <= 0)
        {
            // The date is between the start and end dates
            Button_1_2.IsVisible = true;
        }
        else
        {
            // The date is not between the start and end dates
            Button_1_2.IsVisible = false;
        }

        if (date_Q1_3.CompareTo(fromdate) >= 0 && date_Q1_3.CompareTo(untildate) <= 0)
        {
            // The date is between the start and end dates
            Button_1_3.IsVisible = true;
        }
        else
        {
            // The date is not between the start and end dates
            Button_1_3.IsVisible = false;
        }

        if (date_Q1_4.CompareTo(fromdate) >= 0 && date_Q1_4.CompareTo(untildate) <= 0)
        {
            // The date is between the start and end dates
            Button_1_4.IsVisible = true;
        }
        else
        {
            // The date is not between the start and end dates
            Button_1_4.IsVisible = false;
        }

        if (date_Q2_1.CompareTo(fromdate) >= 0 && date_Q2_1.CompareTo(untildate) <= 0)
        {
            // The date is between the start and end dates
            Button_2_1.IsVisible = true;
        }
        else
        {
            // The date is not between the start and end dates
            Button_2_1.IsVisible = false;
        }

        Button_2_2.IsVisible = false;

        Button_3_1.IsVisible = false;
        Button_3_2.IsVisible = false;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        switch (button.Text)
        {
            case "VMs im allgemeinen":
                Button_1_1.IsVisible = !isExpanded[0];
                Button_1_2.IsVisible = !isExpanded[0];
                Button_1_3.IsVisible = !isExpanded[0];
                Button_1_4.IsVisible = !isExpanded[0];
                isExpanded[0] = !isExpanded[0];
                break;

            case "Lema (Website, SQL, usw.)":
                Button_2_1.IsVisible = !isExpanded[1];
                Button_2_2.IsVisible = !isExpanded[1];
                isExpanded[1] = !isExpanded[1];
                break;

            case "Smartlearn":
                Button_3_1.IsVisible = !isExpanded[2];
                Button_3_2.IsVisible = !isExpanded[2];
                isExpanded[2] = !isExpanded[2];
                break;

            default:
                break;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        QuestionEntry.Text = string.Empty;
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

    private async void InfoButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("InfoPage");
    }

    private async void AskedQuestion(object sender, EventArgs e)
    {
        if (QuestionEntry.Text != null)
        {
            System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(QuestionEntry.Text, @"^[0-9a-z A-Z,.-]+$");

            if (match.Success)
            {
                string userInput = QuestionEntry.Text;
                await Navigation.PushAsync(new AskedQuestionPage(userInput));
            }
        }
    }
}

