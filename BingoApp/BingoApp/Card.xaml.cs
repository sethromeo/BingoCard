using BingoApp.API;
using BingoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BingoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Card : ContentPage
    {
        User user;
        public Card(User player)
        {
            this.user = player;
            InitializeComponent();
            B1.Text = Convert.ToString(user.card.B[0]);
            B2.Text = Convert.ToString(user.card.B[1]);
            B3.Text = Convert.ToString(user.card.B[2]);
            B4.Text = Convert.ToString(user.card.B[3]);
            B5.Text = Convert.ToString(user.card.B[4]);

            I1.Text = Convert.ToString(user.card.I[0]);
            I2.Text = Convert.ToString(user.card.I[1]);
            I3.Text = Convert.ToString(user.card.I[2]);
            I4.Text = Convert.ToString(user.card.I[3]);
            I5.Text = Convert.ToString(user.card.I[4]);

            N1.Text = Convert.ToString(user.card.N[0]);
            N2.Text = Convert.ToString(user.card.N[1]);
            N3.Text = Convert.ToString(user.card.N[2]);
            N4.Text = Convert.ToString(user.card.N[3]);
            N5.Text = Convert.ToString(user.card.N[4]);

            G1.Text = Convert.ToString(user.card.G[0]);
            G2.Text = Convert.ToString(user.card.G[1]);
            G3.Text = Convert.ToString(user.card.G[2]);
            G4.Text = Convert.ToString(user.card.G[3]);
            G5.Text = Convert.ToString(user.card.G[4]);

            O1.Text = Convert.ToString(user.card.O[0]);
            O2.Text = Convert.ToString(user.card.O[1]);
            O3.Text = Convert.ToString(user.card.O[2]);
            O4.Text = Convert.ToString(user.card.O[3]);
            O5.Text = Convert.ToString(user.card.O[4]);
        }

        private void Background_Change(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundColor = button.BackgroundColor != Color.White ? Color.White : Color.Pink;
        }

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            int res = await REST.SubmitCard(user.playcard_token);
            if (res == 1)
            {
                await Application.Current.MainPage.DisplayAlert("Congratulations", "You Win Bingo!", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Too bad", "You don't have a BINGO", "OK");
            }
        }
    }
}