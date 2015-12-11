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
using ProjectManager.Entity;

namespace ProjectManager.Client.ViewModels
{
    public class EditProjectViewModel : ViewModelBase
    {
        private string _name;
        private string _description;


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyPropertyChanged("Description");
            }
        }


        public ICommand SaveCommand
        {
            get { return new RelayCommand<Window>(Save);}
        }


        private async void Save(Window w)
        {
            var response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5515/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.AccessConfig.AccessToken);

                var proj = new Project() { Name = this.Name, Description = this.Description };

                HttpResponseMessage resp = await client.PostAsync("api/Project",
                    new StringContent("'" + JsonConvert.SerializeObject(proj)+"'", 
                        Encoding.UTF8, "application/json"));
                if (resp.IsSuccessStatusCode)
                {
                    response = await resp.Content.ReadAsStringAsync();
                    w.Close();
                }
                else
                {
                    response = await resp.Content.ReadAsStringAsync();
                    MessageBox.Show(response);
                }
            }
        }
    }
}
