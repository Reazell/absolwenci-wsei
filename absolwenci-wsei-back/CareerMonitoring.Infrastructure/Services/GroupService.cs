using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Infrastructure.Repositories.Interfaces;
using CareerMonitoring.Infrastructure.Services.Interfaces;

namespace CareerMonitoring.Infrastructure.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUnregisteredUserRepository _unregisteredUserRepository;
        private readonly IUserGroupRepository _userGroupRepository;


        public GroupService(IGroupRepository groupRepository, IUnregisteredUserRepository unregisteredUserRepository, IUserGroupRepository userGroupRepository)
        {
            _groupRepository = groupRepository;
            _unregisteredUserRepository = unregisteredUserRepository;
            _userGroupRepository = userGroupRepository;
        }

        public async Task<int> CreateAsync(string name)
        {
            Group group = new Group(name);
            await _groupRepository.CreateAsync(group);
            return group.Id;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _groupRepository.ExistsByNameAsync(name);
        }

        public async Task AddUserAsync(int groupId, int userId)
        {
            UnregisteredUser user = await _unregisteredUserRepository.GetByIdAsync(userId);
            Group group = await _groupRepository.GetByIdAsync(groupId);
            await _userGroupRepository.AddUserAsync(new UserGroup{User = user,Group = group});
        }

        public async Task RemoveUserAsync(int groupId, int userId)
        {
            UserGroup userGroup = await _userGroupRepository.GetByIdsAsync(userId, groupId);
            await _userGroupRepository.RemoveUserAsync(userGroup);
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _groupRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _groupRepository.GetAllAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Group group = await _groupRepository.GetByIdAsync(id);
            await _groupRepository.DeleteAsync(group);
        }
    }
}