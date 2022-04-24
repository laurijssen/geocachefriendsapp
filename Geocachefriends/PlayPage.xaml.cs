using System;
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

        public GeofriendsClient Client { get; set; }

        public Location lastLocation { get; set; }
        public PlayPage()
        {
            InitializeComponent();
            init();

            Appearing += OnAppear;
        }

        protected override void OnDisappearing()
        {
        }

        private async void OnAppear(object sender, EventArgs e)
        {
            await Client.GetUser();
        }

        private async void updateLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var loc = await Geolocation.GetLocationAsync(request);

                if (loc != null && (loc != lastLocation))
                {
                    lastLocation = loc;

                    Position position = new Position(loc.Latitude, loc.Longitude);

                    var span = new MapSpan(position, 0.05, 0.05);

                    map.MoveToRegion(span);
                    map.IsShowingUser = true;
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
            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                updateLocation();
                return true;
            });
        }
    }
}