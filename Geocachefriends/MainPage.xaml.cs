using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Geocachefriends
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private GeofriendsClient client { get; set; }
        private LoginPage Login { get; set; } = new LoginPage();

        private PlayPage Play { get; set; } = new PlayPage();

        public MainPage()
        {
            InitializeComponent();

            client = new GeofriendsClient();

            Play.Client = client;
            Login.Client = client;
        }

        async void LoginButtonClicked(object sender, EventArgs e)
        {
            Play.Token = Login.Token = null;
            await Navigation.PushModalAsync(Login, true);            
        }

        async void PlayButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(Login, true);
        }

        protected override async void OnAppearing()
        {
            if (Login.Token == null || !string.IsNullOrEmpty(Play.Token)) return;

            if (Login.Token == string.Empty)
            {
                await DisplayAlert("Error", "Invalid Login, try again or register account", "OK");
            }
            else
            {
                Play.Token = Login.Token;
                await Navigation.PushModalAsync(Play);
            }
        }
    }
}