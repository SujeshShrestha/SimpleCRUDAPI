using SimpleCRUDAPI.Model;

namespace SimpleCRUDAPI.Interface
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> GetAllAsync();
        Task<UserProfile> GetByIdAsync(int id);
        Task<UserProfile> AddAsync(UserProfile userProfile);
        Task<UserProfile> UpdateAsync(UserProfile userProfile);
        Task<bool> DeleteAsync(int id);
    }
}

