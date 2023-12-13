using System;
using Xamarin.Forms;
using RCFeedback.Data;
using RCFeedback.Models;

[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")]
[assembly: ExportFont("Cinzel-ExtraBold.ttf", Alias = "Cinzel-ExtraBold")]

namespace RCFeedback
{
    public partial class RatingPage : ContentPage
    {
        private string _name;
        private string _email;
        private string _orderNumber;

        public RatingPage(string name, string email, string orderNumber)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            _name = name;
            _email = email;
            _orderNumber = orderNumber;
        }
        void OnEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            var editor = (Editor)sender;
            int lineHeight = 20; 

            int lineCount = editor.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Length;

            int minHeight = 110;
            int maxHeight = 10000;

            int newHeight = Math.Max(minHeight, Math.Min(maxHeight, lineHeight * lineCount));

            editor.HeightRequest = newHeight;
        }
        
        private async void EndButton(object sender, EventArgs e)
        {
            var feedback = new Feedback
            {
                Name = _name,
                Email = _email,
                OrderNumber = _orderNumber,

                QualityRating = QualityRatingBar.SelectedStarValue,
                DesignRating = DesignRatingBar.SelectedStarValue,
                PriceRating = PricePolicyRatingBar.SelectedStarValue,
                DeliveryRating = DeliveryRatingBar.SelectedStarValue,
                Comment = MyEditor.Text
            };


            await App.FeedbackDatabase.SaveItemAsync(feedback);
            await Navigation.PushModalAsync(new NavigationPage(new EndPage()));

        }


    }
}
