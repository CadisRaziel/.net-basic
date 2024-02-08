using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.Contracts
{
    public interface IUserRepository
    {
        public bool ExistUserWithEmail(string email);
        public User GetUserByEmail(string email);
    }
}
