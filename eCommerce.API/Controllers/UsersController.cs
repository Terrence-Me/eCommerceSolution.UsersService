using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserByUserId(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            return BadRequest("Invalid user id");
        }
        UserDTO user = await _usersService.GetUserByUserId(userId);

        if (user is null)
        {
            return NotFound("User not found");
        }

        return Ok(user);
    }
}
