using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using Jira_Bulk_Issues_Helper.Models;
using Jira_Bulk_Issues_Helper.Utils;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace Jira_Bulk_Issues_Helper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Variables
        private UrlBuilder urlBuilder;
        private RestClient client;

        private string email = "dineshthangavel47@gmail.com";
        private string apiToken = "JRkbgJ8ChzmWakHKFhqr6912";
        private string domainName = "devil7dk";
        private bool isLoggedIn = false;
        private ObservableCollection<Project> projects = new ObservableCollection<Project>();
        private Project selectedProject = null;
        private int issuesMaxCount = 1;
        #endregion

        #region Properties
        public IMessageBoxService MessageBoxService { get { return GetService<IMessageBoxService>(); } }

        public string EMail { get => email; set => SetProperty(ref email, value, "EMail"); }
        public string APIToken { get => apiToken; set => SetProperty(ref apiToken, value, "APIToken"); }
        public string DomainName { get => domainName; set => SetProperty(ref domainName, value, "DomainName"); }
        public bool IsLoggedIn { get => isLoggedIn; set => SetProperty(ref isLoggedIn, value, "IsLoggedIn"); }
        public ObservableCollection<Project> Projects { get => projects; set => SetProperty(ref projects, value, "Projects"); }
        public Project SelectedProject { get => selectedProject; set => SetProperty(ref selectedProject, value, "SelectedProject"); }
        public int IssuesMaxCount { get => issuesMaxCount; set => SetProperty(ref issuesMaxCount, value, "IssuesMaxCount"); }
        #endregion

            #region Commands
        public AsyncCommand Login { get; }
        #endregion

        #region Command Implementation
        private Task login()
        {
            return Task.Run(() =>
            {
                urlBuilder = new UrlBuilder(DomainName);
                client = new RestClient(urlBuilder.getBaseUrl());

                client.Authenticator = new HttpBasicAuthenticator(EMail, APIToken);

                RestRequest request = new RestRequest(urlBuilder.getMetaUrl(), Method.GET);
                RestResponse response = (RestResponse)client.Execute(request);
                if (response.IsSuccessful)
                {
                    SiteMeta siteMeta = JsonConvert.DeserializeObject<SiteMeta>(response.Content);
                    if (siteMeta != null)
                    {
                        IsLoggedIn = true;
                        Projects = new ObservableCollection<Project>(siteMeta.projects);
                        ShowMessage("Authendication successful!");
                    }
                }
            });
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            this.Login = new AsyncCommand(login);
        }
        #endregion

        #region Private Methods
        private void ShowMessage(string messageBoxText)
        {
            Application.Current.Dispatcher.Invoke(() => MessageBoxService.ShowMessage(messageBoxText));
        }
        #endregion
    }
}