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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjectManager.Client.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {

        }
        public string Email { get; set; }
        public string Password { get; set; }

        private async void Login(Window currentWindow)
        {
            var response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5515/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var body = new List<KeyValuePair<string, string>>();
                body.Add(new KeyValuePair<string, string>("username", Email));
                body.Add(new KeyValuePair<string, string>("password", Password));
                body.Add(new KeyValuePair<string, string>("grant_type", "password"));

                HttpResponseMessage resp = await client.PostAsync("token", new FormUrlEncodedContent(body));
                if (resp.IsSuccessStatusCode)
                {
                    response = await resp.Content.ReadAsStringAsync();
                    JObject obj = JObject.Parse(response);
                    string accessToken = obj["access_token"].ToString();
                    string userName = obj["userName"].ToString();

                    Configuration.AccessConfig.AccessToken = accessToken;
                    Configuration.AccessConfig.CurrentUser = userName;

                    var mWindow = new MainWindow();
                    mWindow.Show();
                    currentWindow.Hide();
                }
                else
                {
                    response = await resp.Content.ReadAsStringAsync();
                    MessageBox.Show(response);
                }
            }
        }

        public ICommand LoginCommand
        {
            get { return new RelayCommand<Window>(Login);}
        }
    }
}
