using System;
using PatientGuidance.App.ViewModels;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Xamarin.Forms;

namespace PatientGuidance.App.Views
{
    public partial class VideoPage : ContentPage
    {
        public VideoPage()
        {
            InitializeComponent();
        }

        private void PlayStopButton_OnClicked(object sender, EventArgs e)
        {
            if (BindingContext is VideoPageViewModel vm)
            {
                if (PlayStopButton.Text.Equals("נגן"))
                {
                    CrossMediaManager.Current.Play("https://drive.google.com/uc?export=download&id=1XSGHHGBCekqCWmaY3vAETPfkfsb3YkK2", MediaFileType.Video);
                    PlayStopButton.Text = "עצור";
                }
                else
                {
                    CrossMediaManager.Current.Stop();
                    PlayStopButton.Text = "נגן";
                }
            }
        }
    }
}
