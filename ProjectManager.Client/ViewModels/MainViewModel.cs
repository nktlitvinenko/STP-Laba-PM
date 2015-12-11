using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MVVMCommon;
using ProjectManager.Client.Enums;

namespace ProjectManager.Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _connectionState = ConnectionState.IsOnline;
            CurrentUser = Configuration.AccessConfig.CurrentUser;
        }


        private ConnectionState _connectionState;

        public string CurrentUser { get; set; }

        public ConnectionState ConnectionState
        {
            get { return _connectionState; }
            set
            {
                _connectionState = value;
                NotifyPropertyChanged("ConnectionState");
            }
        }


        public ICommand AccessTokenCommand
        {
            get { return new RelayCommand(c => GetAccessToken()); }
        }
        public ICommand ForwardCommand
        {
            get { return new RelayCommand<Frame>(Forward); }
        }
        public ICommand BackCommand
        {
            get { return new RelayCommand<Frame>(Back);}
        }
        public ICommand UserCommand
        {
            get { return new RelayCommand<Frame>(User);}
        }
        public ICommand DashboardCommand
        {
            get { return new RelayCommand<Frame>(Dashboard);}
        }


        private void Forward(Frame obj)
        {
            if (obj.NavigationService.CanGoForward)
                obj.NavigationService.GoForward();
        }
        private void Back(Frame obj)
        {
            if (obj.NavigationService.CanGoBack)
                obj.NavigationService.GoBack();
        }
        private void Dashboard(Frame obj)
        {
            obj.NavigationService.Navigate(new Uri("Pages/MainPage.xaml", UriKind.Relative));
        }
        private void User(Frame obj)
        {
            obj.NavigationService.Navigate(new Uri("Pages/UserPage.xaml", UriKind.Relative));
        }
        private void GetAccessToken()
        {
            MessageBox.Show(Configuration.AccessConfig.AccessToken, "Access token", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
