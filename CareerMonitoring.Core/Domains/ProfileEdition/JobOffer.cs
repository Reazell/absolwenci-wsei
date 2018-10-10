namespace CareerMonitoring.Core.Domains {
    public class JobOffer {
        public int Id { get; private set; }
        public string JobType { get; private set; }
        public string Position { get; private set; }
        public string CompanyName { get; private set; }
        public string Location { get; private set; }
        public string ContactPerson { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Description { get; private set; }
        public string Email { get; private set; }
        public string WebsiteAddress { get; private set; }

        public JobOffer () { }

        public JobOffer (string jobType,
            string position, string companyName,
            string location, string contactPerson,
            string phoneNumber, string description,
            string email, string webSiteAddress) {
            SetJobType(jobType);
            SetPosition(position);
            SetCompanyName(companyName);
            SetLocation(location);
            SetContactPerson(contactPerson);
            SetPhoneNumber(phoneNumber);
            SetDescription(description);
            SetEmail(email);
            SetWebSiteAdress(webSiteAddress);
        }

        public void SetJobType (string jobType) {
            JobType = jobType;
        }

        public void SetPosition (string position) {
            Position = position;
        }

        public void SetCompanyName (string companyName) {
            CompanyName = companyName;
        }

        public void SetLocation (string location) {
            Location = location;
        }

        public void SetContactPerson (string contactPerson) {
            ContactPerson = contactPerson;
        }

        public void SetPhoneNumber (string phoneNumber) {
            PhoneNumber = phoneNumber;
        }

        public void SetDescription (string description) {
            Description = description;
        }

        public void SetEmail (string email) {
            Email = email;
        }

        public void SetWebSiteAdress (string webSiteAddress) {
            WebsiteAddress = webSiteAddress;
        }

    }
}