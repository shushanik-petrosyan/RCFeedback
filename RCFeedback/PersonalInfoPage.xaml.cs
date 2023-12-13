using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;

[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")]
[assembly: ExportFont("Cinzel-ExtraBold.ttf", Alias = "Cinzel-ExtraBold")]



namespace RCFeedback
{
    public partial class PersonalInfoPage : ContentPage
    {
        public PersonalInfoPage()
        {
            InitializeComponent(); 
            NavigationPage.SetHasNavigationBar(this, false); 
        }

        private async void AddItemButton(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameEditor.Text) || string.IsNullOrWhiteSpace(EmailEditor.Text) || string.IsNullOrWhiteSpace(OrderNumberEditor.Text))
            {
                await PopupNavigation.Instance.PushAsync(new CustomErrorPopupPage());
            }
            else
            {
                var name = NameEditor.Text;
                var email = EmailEditor.Text;
                var orderNumber = OrderNumberEditor.Text;

                await Navigation.PushModalAsync(new NavigationPage(new RatingPage(name, email, orderNumber)));
            }
        }
    }
}

      
