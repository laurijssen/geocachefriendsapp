using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Geocachefriends
{
    public partial class App : Application
    {
        public static INavigation GlobalNavigation { get; private set; }


        public App()
        {
            InitializeComponent();

            var rootPage = new NavigationPage(new MainPage());

            GlobalNavigation = rootPage.Navigation;

            MainPage = rootPage;
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
