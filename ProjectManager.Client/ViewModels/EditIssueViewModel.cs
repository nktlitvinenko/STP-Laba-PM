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
using ProjectManager.Entity;
using ProjectManager.Entity.Enumerations;

namespace ProjectManager.Client.ViewModels
{
    public class EditIssueViewModel : ViewModelBase
    {
        private string _name;
        private string _description;
        private string _environment;
        private IssueType _type;
        private IssuePriority _priority;
        private string _projectId;

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
        public string Environment
        {
            get { return _environment; }
            set
            {
                _environment = value;
                NotifyPropertyChanged("Environment");
            }
        }
        public IssueType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                NotifyPropertyChanged("Type");
            }
        }
        public IssuePriority Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                NotifyPropertyChanged("Priority");
            }
        }
        public string ProjectId
        {
            get { return _projectId; }
            set
            {
                _projectId = value;
                NotifyPropertyChanged("ProjectId");
            }
        }


        public ICommand SaveCommand
        {
            get { return new RelayCommand<Window>(Save); }
        }


        private async void Save(Window w)
        {
            var response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5515/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.AccessConfig.AccessToken);

                var issue = new Issue()
                {
                    Name = this.Name, 
                    Description = this.Description, 
                    Environment = this.Environment, 
                    Type = this.Type, 
                    Priority = this.Priority,
                    Project_Id = new Guid(this.ProjectId)
                };

                HttpResponseMessage resp = await client.PostAsync("api/Issue",
                    new StringContent("'" + JsonConvert.SerializeObject(issue) + "'",
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
