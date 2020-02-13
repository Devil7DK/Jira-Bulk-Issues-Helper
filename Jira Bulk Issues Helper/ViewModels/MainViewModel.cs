using System;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace Jira_Bulk_Issues_Helper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Variables
        private string email = "";
        private string apiToken = "";
        private string domainName = "";
        #endregion

        #region Properties
        public string EMail { get => email; set => SetProperty(ref email, value, "EMail"); }
        public string APIToken { get => apiToken; set => SetProperty(ref apiToken, value,"APIToken"); }
        public string DomainName { get => domainName; set => SetProperty(ref domainName, value, "DomainName"); }
        #endregion

        #region Commands
        public AsyncCommand Login { get; }
        #endregion

        #region Command Implementation
        private Task login ()
        {
            return Task.Run(() =>
            {
                /// TODO
            });
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            this.Login = new AsyncCommand(login);
        }
        #endregion
    }
}