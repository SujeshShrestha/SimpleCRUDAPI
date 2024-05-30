using Microsoft.EntityFrameworkCore;
using SimpleCRUDAPI.Interface;
using SimpleCRUDAPI.Model;

namespace SimpleCRUDAPI
{
    public class UserProfileRepositories : IUserProfileRepository
    {
        private readonly DatabaseContext _context;
        public UserProfileRepositories(DatabaseContext context )
        {
            _context = context;
                
        }
        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _context.UserProfile.ToListAsync();
        }

        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await _context.UserProfile.FindAsync(id);
        }

        public async Task<UserProfile> AddAsync(UserProfile userProfile)
        {
            
            _context.UserProfile.Add(userProfile);
            await _context.SaveChangesAsync();
            return userProfile;
        }

        public async Task<UserProfile> UpdateAsync(UserProfile userProfile)
        {
            _context.Entry(userProfile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return userProfile;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userProfile = await _context.UserProfile.FindAsync(id);
            if (userProfile == null)
            {
                return false;
            }

            _context.UserProfile.Remove(userProfile);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
