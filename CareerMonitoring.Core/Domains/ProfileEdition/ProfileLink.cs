using CareerMonitoring.Core.Domains.Abstract;

namespace CareerMonitoring.Core.Domains.Profile {
    public class ProfileLink {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public int AccountId { get; private set; }
        public Account Account { get; private set; }

        protected ProfileLink () { }

        public ProfileLink (string content) {
            Content = content;
        }
    }
}