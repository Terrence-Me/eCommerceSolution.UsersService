using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;
internal class UserRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        // Generate a new user id
        user.UserId = Guid.NewGuid();

        // SQL Query to insert a new user
        string query = "INSERT INTO public.\"Users\"(\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";

        int rowsAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

        if (rowsAffected > 0)
        {
            return user;
        }
        else
        {
            return null;
        }

        //return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {

        // SQL to select a user by email and password   
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";

        var parameters = new { Email = email, Password = password };

        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);


        return user;

    }

    public async Task<ApplicationUser?> GetUserByUserId(Guid? userId)
    {
        string query = "SELECT * FROM public.\"Users\" WHERE \"UserId\" = @UserID";
        var parameters = new { UserId = userId };

        return await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
    }
}
