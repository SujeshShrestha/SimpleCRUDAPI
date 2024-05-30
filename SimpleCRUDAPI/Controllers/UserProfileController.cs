using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using SimpleCRUDAPI.Interface;
using SimpleCRUDAPI.Model;

namespace SimpleCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfile;
        public UserProfileController(IUserProfileRepository userProfile)
        {
            _userProfile = userProfile;
        }
        // GET: api/UserProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfile>>> GetUserProfiles()
        {
            var userProfiles = await _userProfile.GetAllAsync();
            return Ok(userProfiles);
        }

        // GET: api/UserProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfile>> GetUserProfile(int id)
        {
            var userProfile = await _userProfile.GetByIdAsync(id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        // POST: api/UserProfiles
        [HttpPost]
        public async Task<IActionResult> PostUserProfile(UserProfile userProfile)
        {
            if (userProfile.DateOfBirth == DateTime.MinValue && userProfile.DateOfBirth.Year == DateTime.Now.Year)
            {
                throw new ArgumentException("Date of birth must not be the default value (DateTime.MinValue).");
            }
            var createdUserProfile = await _userProfile.AddAsync(userProfile);
            return CreatedAtAction(nameof(GetUserProfile), new { id = createdUserProfile.Id }, createdUserProfile);
        }

        // PUT: api/UserProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProfile(int id, UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return BadRequest();
            }

            var updatedUserProfile = await _userProfile.UpdateAsync(userProfile);

            if (updatedUserProfile == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/UserProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            var success = await _userProfile.DeleteAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
