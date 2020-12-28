using System;
using System.Collections.Generic;
using StatusBarBug.Services;
using Xamarin.Forms;

namespace StatusBarBug
{
    public partial class SecondFullScreenPage : ContentPage
    {
        public SecondFullScreenPage()
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

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            App app = (App)App.Current;
            app.MainPage.Navigation.PopAsync();
        }
    }
}
