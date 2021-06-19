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
        public LoginViewModel Model { get; set; }

        public LoginPage()
        {
            Model = new LoginViewModel();
            BindingContext = Model;
            Model.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");

            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                Model.SubmitCommand.Execute(null);
            };
        }
    }
}
