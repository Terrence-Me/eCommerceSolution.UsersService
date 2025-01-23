using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// contract for users service
/// </summary>
public interface IUsersService
{

    /// <summary>
    /// method to handle user login
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

    /// <summary>
    /// method to handle user registration
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>

    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);

    /// <summary>
    /// retrieve a user by userId
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<UserDTO> GetUserByUserId(Guid userId);
}
