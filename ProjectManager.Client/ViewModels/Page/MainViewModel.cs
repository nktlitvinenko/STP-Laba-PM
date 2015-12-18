using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ProjectManager.Client.Windows.Issue;
using ProjectManager.Client.Windows.Project;
using ProjectManager.Entity;

namespace ProjectManager.Client.ViewModels.Page
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            GetProjects();
        }

        private ObservableCollection<Project> _project = new ObservableCollection<Project>();
        private ObservableCollection<Issue> _issues = new ObservableCollection<Issue>(); 
        private Project _selectedProject;
        private Issue _selectedIssue;
        private Issue _currentIssue;


        public ObservableCollection<Project> Projects
        {
            get { return _project;}
            set
            {
                _project = value;
                NotifyPropertyChanged("Projects");
            }
        }
        public ObservableCollection<Issue> Issues
        {
            get { return _issues; }
            set
            {
                _issues = value;
                NotifyPropertyChanged("Issues");
            }
        }

        public Project SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;
                if(value!=null)
                    GetIssueByProject(value.Id);
                NotifyPropertyChanged("SelectedProject");
            }
        }
        public Issue SelectedIssue
        {
            get { return _selectedIssue; }
            set
            {
                _selectedIssue = value;
                if(_selectedIssue != null)
                    GetIssueById(_selectedIssue.Id);
                NotifyPropertyChanged("SelectedIssue");
            }
        }
        public Issue CurrentIssue
        {
            get { return _currentIssue; }
            set
            {
                _currentIssue = value;
                NotifyPropertyChanged("CurrentIssue");
            }
        }


        public ICommand AddProjectWindowCommand
        {
            get { return new RelayCommand(c => AddProjectWindow()); }
        }
        public ICommand EditProjectWindowCommand
        {
            get { return new RelayCommand(c => EditProjectWindow()); }
        }
        public ICommand DeleteProjectCommand
        {
            get { return new RelayCommand(c => DeleteProject());}
        }

        private void AddProjectWindow()
        {
            EditProject ep = new EditProject();
            ep.ShowDialog();
            //TODO remove when SignalR is working
            GetProjects();
        }
        private void EditProjectWindow()
        {
            
        }
        private async void DeleteProject()
        {
            var c = MessageBox.Show("Are you really want to delete this project?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (c != MessageBoxResult.Yes)
                return;
            var response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5515/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.AccessConfig.AccessToken);

                HttpResponseMessage resp = await client.DeleteAsync("api/Project?id="+SelectedProject.Id);

                if (resp.IsSuccessStatusCode)
                {
                    response = await resp.Content.ReadAsStringAsync();
                    //TODO remove when SignalR is working
                    GetProjects();
                }
                else
                {
                    MessageBox.Show(response, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        public ICommand AddIssueWindowCommand
        {
            get { return new RelayCommand(c => AddIssueWindow()); }
        }
        public ICommand EditIssueWindowCommand
        {
            get { return new RelayCommand(c => EditIssueWindow()); }
        }
        public ICommand DeleteIssueCommand
        {
            get { return new RelayCommand(c => DeleteIssue()); }
        }

        private void AddIssueWindow()
        {
            //TODO remove when SignalR is working
            if (SelectedProject != null)
            {
                EditIssue ep = new EditIssue(SelectedProject.Id);
                ep.ShowDialog();
                GetIssueByProject(SelectedProject.Id);
            }
        }
        private void EditIssueWindow()
        {

        }
        private async void DeleteIssue()
        {
            var c = MessageBox.Show("Are you really want to delete this issue?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (c != MessageBoxResult.Yes)
                return;
            var response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5515/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.AccessConfig.AccessToken);

                HttpResponseMessage resp = await client.DeleteAsync("api/Issue?id=" + SelectedIssue.Id);

                if (resp.IsSuccessStatusCode)
                {
                    response = await resp.Content.ReadAsStringAsync();
                    //TODO remove when SignalR is working
                    if(SelectedProject != null)
                        GetIssueByProject(SelectedProject.Id);
                }
                else
                {
                    MessageBox.Show(response, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private async void GetIssueByProject(Guid projectId)
        {
            var response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5515/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.AccessConfig.AccessToken);

                HttpResponseMessage resp = await client.GetAsync("api/Issue?projectId=" + projectId.ToString());

                if (resp.IsSuccessStatusCode)
                {
                    response = await resp.Content.ReadAsStringAsync();
                    Issues = new ObservableCollection<Issue>(JsonConvert.DeserializeObject<List<Issue>>(response));
                }
            }
        }
        private async void GetIssueById(Guid issueId)
        {
            var response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5515/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.AccessConfig.AccessToken);

                HttpResponseMessage resp = await client.GetAsync("api/Issue?issueId=" + issueId);

                if (resp.IsSuccessStatusCode)
                {
                    response = await resp.Content.ReadAsStringAsync();
                    CurrentIssue = JsonConvert.DeserializeObject<Issue>(response);
                }
            }
        }
        private async void GetProjects()
        {
            var response = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5515/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.AccessConfig.AccessToken);

                HttpResponseMessage resp = await client.GetAsync("api/Project");

                if (resp.IsSuccessStatusCode)
                {
                    response = await resp.Content.ReadAsStringAsync();
                    Projects = new ObservableCollection<Project>(JsonConvert.DeserializeObject<List<Project>>(response));
                }
            }
        }
    }
}
