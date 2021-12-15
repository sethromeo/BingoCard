using BingoApp.API;
using BingoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BingoApp
{
    public partial class MainPage : ContentPage
    {
        private User player;
        public MainPage()
        {
            InitializeComponent();
        }
        public User Player
        {
            get => player;
            set => SetProperty(ref player, value);
        }

        private bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            player = await REST.GetPlayer(tokenEntry.Text);
            var result = await this.DisplayAlert("Success!", player.playcard_token, "Cancel", "Ok");
            
            if (result)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Card(player));
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Card(player));
            }
        }
    }
}
