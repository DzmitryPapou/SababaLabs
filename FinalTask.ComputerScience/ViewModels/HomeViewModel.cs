using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Caliburn.Micro;
using FinalTask.ComputerScience.Logic;
using FinalTask.ComputerScience.Logic.Interfaces;
using FinalTask.ComputerScience.Logic.Models;

namespace FinalTask.ComputerScience.ViewModels
{
    public class HomeViewModel : Screen
    {
        private IAuthenticateService auth;
        private IFacebookFriends friends;
        private IFacebookMusic musicList;

        public HomeViewModel(IFacebookMusic musicList, IAuthenticateService auth, IFacebookFriends friends)
        {
            this.musicList = musicList;
            this.auth = auth;
            this.friends = friends;
        }

        public bool CanLogin { get; set; } = true;

        public bool ShowFriends { get; set; }

        public bool ShowMusic { get; set; }

        public double ProgressCountMusic { get; set; }
        public double ProgressCountFriends { get; set; }
        public BindableCollection<Friends> FriendsList { get; } = new BindableCollection<Friends>();
        public BindableCollection<Music> Musics { get; } = new BindableCollection<Music>();

        public async Task Login(object sender, RoutedEventArgs e)
        {
            try
            {
                await auth.AuthenticateFacebookAsync();
                CanLogin = false;
            }
            catch (AuthentificateException)
            {
                var messageDialog = new MessageDialog("Authentificate Error! Please login again!");
                await messageDialog.ShowAsync();
                auth.Logout();
                CanLogin = true;
            }
        }

        public async Task GetFriends(object sender, RoutedEventArgs e)
        {
            ShowFriends = true;
            ShowMusic = false;
            try
            {
                Progress<double> progress = new Progress<double>(i => ProgressCountFriends = i);
                var fbFriends = await friends.GetFriendsAsync(progress);

                if (FriendsList.Count > 0)
                {
                    FriendsList.Clear();
                }

                FriendsList.AddRange(fbFriends);
            }

            catch (GetFriendsException)
            {
                var messageDialog = new MessageDialog("Friends List not received! Please login again!");
                await messageDialog.ShowAsync();
                auth.Logout();
                CanLogin = true;
            }
        }

        public async Task GetMusic(object sender, RoutedEventArgs e)
        {
            ShowFriends = false;
            ShowMusic = true;

            try
            {
                Progress<double> progress = new Progress<double>(i => ProgressCountMusic = i);
                var fbMusic = await musicList.GetMusicAsync(progress);

                if (Musics.Count > 0)
                {
                    Musics.Clear();
                }
                Musics.AddRange(fbMusic.Values);
            }

            catch (GetMusicException)
            {
                var messageDialog = new MessageDialog("Music not received! Please login again!");
                await messageDialog.ShowAsync();
                auth.Logout();
                CanLogin = true;
            }
        }

        public void Logout(object sender, RoutedEventArgs e)
        {
            Musics.Clear();
            FriendsList.Clear();
            auth.Logout();
            CanLogin = true;
        }
    }
}
