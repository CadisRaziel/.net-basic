using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.Repositories.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly RockerSeatAuctionDbContext _dbContext;
        public UserRepository(RockerSeatAuctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ExistUserWithEmail(string email)
        {
            return _dbContext.Users.Any(x => x.Email.Equals(email));
        }   

        public User GetUserByEmail(string email)
        {
            return _dbContext.Users.First(x => x.Email.Equals(email));
        }    
    }
}
