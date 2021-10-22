using AppUsaditos.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppUsaditos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new Views.LoginView();
            //MainPage = new NavigationPage(new SettingPage());
            //MainPage = new Views.ProductsView();
            //MainPage = new LoginView();

            string uname = Preferences.Get("Username", String.Empty);
            if (string.IsNullOrEmpty(uname))
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new ProductsView();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
