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
        private LoginPage Login { get; set; } = new LoginPage();

        public MainPage()
        {
            InitializeComponent();
        }

        async void LoginButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(Login, true);
        }

        async void PlayButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(Login, true);
        }

        protected override bool OnBackButtonPressed()
        {
            Task<bool> action = DisplayAlert("Quitter?", "Voulez-vous quitter l'application?", "Oui", "Non");
            if (action.Result)
                DisplayAlert("debugvalue", "TRUE", "ok");

            return true;
        }
    }
}