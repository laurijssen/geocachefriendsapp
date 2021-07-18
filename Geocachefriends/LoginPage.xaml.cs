using Geocachefriends.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Geocachefriends
{
    public partial class LoginPage : ContentPage
    {
        public string Token { get; set; }
        public LoginPage()
        {            
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                OnLoginClicked(sender, e);
            };
        }

        public async void OnLoginClicked(object sender, EventArgs e)
        {
            if (Email.Text == null || Password.Text == null)
            {
                await DisplayAlert("Error", "Invalid password / user", "OK");
                return;
            }
            Email.Text = Email.Text.Trim();
            Password.Text = Password.Text.Trim();

            RestService c = new RestService(Email.Text, Password.Text);

            Token = await c.GetTokenAsync();

            await Navigation.PopModalAsync();
        }
    }
}
