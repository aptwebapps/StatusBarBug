using System;
using StatusBarBug.Services;
using Xamarin.Forms;

namespace StatusBarBug
{
    public partial class FullScreenPage : ContentPage
    {
        public FullScreenPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            IFullScreenService service = DependencyService.Get<IFullScreenService>();
            service.SetFullScreen(true);
        }

        protected override void OnDisappearing()
        {
            IFullScreenService service = DependencyService.Get<IFullScreenService>();
            service.SetFullScreen(false);
            base.OnDisappearing();
        }

        void Button_Clicked(Object sender, EventArgs e)
        {
            App app = (App)App.Current;
            app.MainPage.Navigation.PopAsync();
        }

        void Button_Clicked_1(Object sender, EventArgs e)
        {
            App app = (App)App.Current;
            app.MainPage.Navigation.PushAsync(new SecondFullScreenPage());
        }
    }
}
