using System.Collections.Generic;
using System.Linq;
using CareerMonitoring.Core.Domains.ImportFile;

namespace CareerMonitoring.Core.Domains
{
    public class Group
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<UserGroup> Users { get; private set; } = new List<UserGroup>();

        public Group(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}