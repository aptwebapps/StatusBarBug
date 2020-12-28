using System;
using Xamarin.Forms;
using UIKit;
using StatusBarBug.Services;

[assembly: Dependency(typeof(StatusBarBug.iOS.Services.FullScreenService))]
namespace StatusBarBug.iOS.Services
{
    public class FullScreenService : IFullScreenService
    {
        public FullScreenService()
        {
        }

        public void SetFullScreen(bool isFullScreen)
        {
            Console.WriteLine("DEPENDECY DEBUG");
            AppDelegate appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
            appDelegate.SetFullscreen(isFullScreen);
        }
    }
}
