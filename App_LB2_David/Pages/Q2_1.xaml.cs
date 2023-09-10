namespace App_LB2_David.Pages;

public partial class Q2_1 : ContentPage
{
    public Q2_1()
    {
        InitializeComponent();
    }

    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = CommentEntry.Text;
    }

    void OnEntryCompleted(object sender, EventArgs e)
    {
        string text = ((Entry)sender).Text;
    }

    void ExpandTheEntry(object sender, EventArgs e)
    {
        EntryBorder.HeightRequest = 200;
        EntryBorder.TranslationY -= 160;

        OpenCommentButton.IsVisible = false;
        CommentEntry.IsVisible = true;

        CommentEntryElement1.IsVisible = true;
        CommentEntryElement2_1.IsVisible = true;
        CommentEntryElement2_2.IsVisible = true;
        CommentEntryElement3.IsVisible = true;
        CommentEntryElement4.IsVisible = true;
        CommentEntryElement5.IsVisible = true;

        CommentEntry.HorizontalTextAlignment = TextAlignment.Start;
    }
    void ShrinkTheEntryDelete(object sender, EventArgs e)
    {
        Alert.IsVisible = false;

        EntryBorder.HeightRequest = 40;
        EntryBorder.TranslationY += 160;

        OpenCommentButton.IsVisible = true;
        CommentEntry.IsVisible = false;
        CommentEntry.Text = null;
        CommentEntryElement2_1.Value = 0;
        CommentEntryElement2_2.Source = "rating_0.png";

        CommentEntryElement1.IsVisible = false;
        CommentEntryElement2_1.IsVisible = false;
        CommentEntryElement2_2.IsVisible = false;
        CommentEntryElement3.IsVisible = false;
        CommentEntryElement4.IsVisible = false;
        CommentEntryElement5.IsVisible = false;

        CommentEntry.HorizontalTextAlignment = TextAlignment.Center;

        if (FixedLayout.TranslationY == -208)
        {
            FixedLayout.TranslationY = 0;
        }
    }

    void ShrinkTheEntrySend(object sender, EventArgs e)
    {
        if (CommentEntryElement2_1.Value == 0 || CommentEntry.Text == null || CommentEntry.Text == "")
        {
            Alert.IsVisible = true;
            FixedLayout.TranslationY = -208;
        }
        else
        {
            Alert.IsVisible = false;
            FixedLayout.TranslationY = 0;

            EntryBorder.HeightRequest = 40;
            EntryBorder.TranslationY += 160;

            OpenCommentButton.IsVisible = true;
            CommentEntry.IsVisible = false;
            CommentEntry.Text = null;
            CommentEntryElement2_1.Value = 0;
            CommentEntryElement2_2.Source = "rating_0.png";

            CommentEntryElement1.IsVisible = false;
            CommentEntryElement2_1.IsVisible = false;
            CommentEntryElement2_2.IsVisible = false;
            CommentEntryElement3.IsVisible = false;
            CommentEntryElement4.IsVisible = false;
            CommentEntryElement5.IsVisible = false;

            CommentEntry.HorizontalTextAlignment = TextAlignment.Center;
        }
    }

    void RatingChanged(object sender, EventArgs e)
    {
        if (CommentEntryElement2_1.Value == 0)
        {
            CommentEntryElement2_2.Source = "rating_0.png";
        }
        if (CommentEntryElement2_1.Value == 1)
        {
            CommentEntryElement2_2.Source = "rating_1.png";
        }
        if (CommentEntryElement2_1.Value == 2)
        {
            CommentEntryElement2_2.Source = "rating_2.png";
        }
        if (CommentEntryElement2_1.Value == 3)
        {
            CommentEntryElement2_2.Source = "rating_3.png";
        }
        if (CommentEntryElement2_1.Value == 4)
        {
            CommentEntryElement2_2.Source = "rating_4.png";
        }
        if (CommentEntryElement2_1.Value == 5)
        {
            CommentEntryElement2_2.Source = "rating_5.png";
        }
    }
    async void GoBackToMainPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage"); //if the page you want to go back is not located in the same folder, just use "//" to go back on the hierarchy
    }
}