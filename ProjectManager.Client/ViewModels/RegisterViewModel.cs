using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MVVMCommon;
using Newtonsoft.Json.Linq;

namespace ProjectManager.Client.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _confirmPassword;


        public string Username
        {
            get { return _username;}
            set
            {
                _username = value;
                NotifyPropertyChanged("UserName");
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged("Password");
            }
        }
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value; 
                NotifyPropertyChanged("ConfirmPassword");
            }
        }


        public ICommand RegisterCommand
        {
            get { return new RelayCommand<Window>(Register);}
        }


        private async void Register(Window w)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5515/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var body = new List<KeyValuePair<string, string>>();
                body.Add(new KeyValuePair<string, string>("Email", Username));
                body.Add(new KeyValuePair<string, string>("Password", Password));
                body.Add(new KeyValuePair<string, string>("ConfirmPassword", ConfirmPassword));

                HttpResponseMessage resp = await client.PostAsync("api/Account/Register", new FormUrlEncodedContent(body));
                if (resp.IsSuccessStatusCode)
                    w.Close();
                else
                    MessageBox.Show("Fail!!!");
            }
        }
    }
}
