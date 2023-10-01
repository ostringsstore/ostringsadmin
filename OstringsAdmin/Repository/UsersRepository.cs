using Microsoft.EntityFrameworkCore;
using Ostrings.Data.Context;
using OstringsAdmin.Contracts.Repositories;
using OstringsAdmin.Data.Models;

namespace OstringsAdmin.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbFactory;

        public UsersRepository(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public async Task<List<User>> GetUsers()
        {
            using var context = dbFactory.CreateDbContext();

            return await context.Users.ToListAsync();
        }
    }
}
