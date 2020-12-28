using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ObjCRuntime;
using UIKit;

namespace StatusBarBug.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        bool _isFullScreen;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public void SetFullscreen(bool isFullScreen)
        {
            _isFullScreen = isFullScreen;
            int value = (int)(_isFullScreen ? UIInterfaceOrientation.LandscapeRight : UIInterfaceOrientation.Unknown);
            UIDevice.CurrentDevice.SetValueForKey(new NSNumber(value), new NSString("orientation"));
            UIApplication.SharedApplication.StatusBarHidden = _isFullScreen;
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, [Transient] UIWindow forWindow)
        {
            if (_isFullScreen)
            {
                return UIInterfaceOrientationMask.LandscapeRight;
            }
            return UIInterfaceOrientationMask.All;
        }
    }
}
