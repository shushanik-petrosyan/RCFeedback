using System;
using Xamarin.Forms;
using RCFeedback.Data;
using System.IO;

namespace RCFeedback
{
    public partial class App : Application
    {
        static FeedbackDatabase feedbackDatabase;
        public static FeedbackDatabase FeedbackDatabase
        {
            get
            {
                if (feedbackDatabase == null)
                {
                    feedbackDatabase = new FeedbackDatabase(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "FeedbackDatabase.db3"));
                }
                return feedbackDatabase;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new MenuPage();
        }

    }


}