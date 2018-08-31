using System;

namespace CareerMonitoring.Infrastructure.Commands.Account {
    public class ChangePasswordByRestoringPassword {
        public Guid Token { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }

    }
}