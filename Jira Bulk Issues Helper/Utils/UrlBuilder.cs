namespace Jira_Bulk_Issues_Helper.Utils
{
    public class UrlBuilder
    {
        #region Variables
        private string domain = "";

        private string baseUrl = "https://{0}.atlassian.net/rest/api/2";
        #endregion

        #region Constructor
        public UrlBuilder(string domain)
        {
            this.domain = domain;
        }
        #endregion

        #region Public Functions
        public string getBaseUrl() => string.Format(this.baseUrl, domain);

        public string getMetaUrl() => "/issue/createmeta";

        public string getIssueCreateUrl() => "/issue";
        #endregion
    }
}
