using System.Collections.Generic;

namespace Jira_Bulk_Issues_Helper.Models
{
    public class SiteMeta
    {
        public string expand { get; set; }
        public IList<Project> projects { get; set; }
    }
}
