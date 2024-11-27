using GitHubActivityApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GitHubActivityApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly GitHubService _gitHubService;

        public GitHubController(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserActivity(string username)
        {
            var activities = await _gitHubService.GetUserActivity(username);

            if (activities == null || !activities.Any())
            {
                return NotFound($"No activities found for user {username}");
            }

            return Ok(activities);
        }
    }
}