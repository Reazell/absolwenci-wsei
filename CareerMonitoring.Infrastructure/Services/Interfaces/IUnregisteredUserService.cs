using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains.ImportFile;

namespace CareerMonitoring.Infrastructure.Services.Interfaces {
    public interface IUnregisteredUserService {
        Task<bool> ExistByEmailAsync (string email);
        Task CreateAsync (string name, string surname, string course,
            DateTime dateOfCompletion, string typeOfStudy, string email);
        Task<IEnumerable<UnregisteredUser>> GetAllAsync ();
        Task UpdateAsync (int id, string name, string surname, string course,
            DateTime dateOfCompletion, string typeOfStudy, string email);
        Task DeleteAsync (int id);
    }
}