using CareerMonitoring.Core.Domains.ImportFile;

namespace CareerMonitoring.Core.Domains
{
    public class UserGroup
    {

        public int UserId { get; set; }
        public UnregisteredUser User { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
        
    }
}