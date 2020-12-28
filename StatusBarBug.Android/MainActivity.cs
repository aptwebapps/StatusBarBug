using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace StatusBarBug.Droid
{
    [Activity(Label = "StatusBarBug", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public void SetFullScreen(bool isFullScreen)
        {
            RunOnUiThread(() =>
            {
                Console.WriteLine($"SetFullScreen() setting to: {isFullScreen}");
                if (isFullScreen)
                {
                    Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(
                        SystemUiFlags.Fullscreen
                        | SystemUiFlags.HideNavigation
                        | SystemUiFlags.Immersive
                        | SystemUiFlags.ImmersiveSticky
                        | SystemUiFlags.LowProfile
                        | SystemUiFlags.LayoutStable
                        | SystemUiFlags.LayoutHideNavigation
                        | SystemUiFlags.LayoutFullscreen
                    );

                    //Window.AddFlags(WindowManagerFlags.Fullscreen);

                    RequestedOrientation = ScreenOrientation.Landscape;
                }
                else
                {
                    Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(
                        SystemUiFlags.LayoutStable
                        | SystemUiFlags.LayoutHideNavigation
                        | SystemUiFlags.LayoutFullscreen
                    );

                    //Window.ClearFlags(WindowManagerFlags.Fullscreen);

                    RequestedOrientation = ScreenOrientation.Unspecified;
                }
            });

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}