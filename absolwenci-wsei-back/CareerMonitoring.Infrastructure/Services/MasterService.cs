using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services
{
    public class MasterService: IMasterService{
        private readonly IMasterRepository _masterRepository;

        public MasterService (IMasterRepository masterRepository) {
            _masterRepository = masterRepository;
        }

        public async Task<bool> ExistByEmailAsync (string email) =>
            await _masterRepository.GetByEmailAsync (email, false) != null;
        public async Task<bool> ExistAsync () =>
           (await _masterRepository.GetAllAsync (false)).Any();
    }
}