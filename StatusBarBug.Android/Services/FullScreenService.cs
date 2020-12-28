using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using StatusBarBug.Services;

[assembly: Dependency(typeof(StatusBarBug.Droid.Services.FullScreenService))]
namespace StatusBarBug.Droid.Services
{
    public class FullScreenService : IFullScreenService
    {
        public FullScreenService()
        {
        }

        public void SetFullScreen(bool isFullScreen)
        {
            var platform = Platform.CurrentActivity as MainActivity;
            platform.SetFullScreen(isFullScreen);
        }
    }
}
