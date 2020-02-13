using System.Collections.Generic;

namespace Jira_Bulk_Issues_Helper.Models
{
    public class Project
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public IList<IssueType> issuetypes { get; set; }
    }
}
