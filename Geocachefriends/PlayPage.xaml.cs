using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Geocachefriends
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayPage : ContentPage
    {
        public string Token { get; set; }
        public PlayPage()
        {
            InitializeComponent();
            init();
        }

        protected override void OnDisappearing()
        {
        }

        private async void updateLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var loc = await Geolocation.GetLocationAsync(request);

                if (loc != null)
                {
                    Position position = new Position(loc.Latitude, loc.Longitude);

                    map.MoveToRegion(new MapSpan(position, 0.05, 0.05));
                    map.IsShowingUser = true;
                    map.IsVisible = true;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Error1", fnsEx.ToString(), "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Unknown error", ex.ToString(), "ok");
            }
        }

        private void init()
        {
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                updateLocation();
                return true;
            });
        }
    }
}