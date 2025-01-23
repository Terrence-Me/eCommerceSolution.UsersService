using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

/// <summary>
/// contract to be implemented by the users repository
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Method to add a new user to the data store. Returns the added user
    /// </summary>
    /// <param name="user"></param>
    /// <returns>  </returns>
    Task<ApplicationUser?> AddUser(ApplicationUser user);


    /// <summary>
    /// Search for a user by email and password. Returns the user if found, otherwise null
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);

    /// <summary>
    /// Retrieves a user my privided userID
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByUserId(Guid? userId);
}
