using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RCFeedback.Data;
using System.IO;

[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")]
[assembly: ExportFont("Montserrat-Bold.ttf", Alias = "Montserrat-Bold")]

namespace RCFeedback
{
    public partial class EndPage : ContentPage
    {
        private FeedbackDatabase _feedbackDatabase;
        public EndPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            CopyDatabase();
        }

        void CopyDatabase()
        {
            _feedbackDatabase = new FeedbackDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                     "FeedbackDatabase.db3")); 
            _feedbackDatabase.CopyDatabaseToExternalStorage();
        }

    }
}
