
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;

[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")] 

namespace RCFeedback
{
    public partial class CustomErrorPopupPage : PopupPage 
    {
        public CustomErrorPopupPage()
        {
            InitializeComponent(); 
        }
        private void OnOkClicked(object sender, EventArgs e) 
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}
