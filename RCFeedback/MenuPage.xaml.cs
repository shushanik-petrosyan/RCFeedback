using System;
using Xamarin.Forms;

[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")] 
[assembly: ExportFont("Cinzel-ExtraBold.ttf", Alias = "Cinzel-ExtraBold")] 

namespace RCFeedback
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent(); 
        }

        private async void StartButton(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new PersonalInfoPage())); 
        }
    }
}