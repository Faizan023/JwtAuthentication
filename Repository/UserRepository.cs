using Context;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public interface IUserRepository
    {
        public List<User> GetUser();
        public User GetById(int Id);
        public void AddUser(User user);
        public void EditUser(User user);
        public User DeleteUser(int Id);
        public bool CheckUser(int Id);
    }

    public class UserRepository : IUserRepository
    {
        readonly UserDbContext _dbContext = new();

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetUser()
        {
            try
            {
                return _dbContext.User.ToList();
            }
            catch
            {
                throw;
            }
        }

        public User GetById(int Id)
        {
            try
            {
                User? user = _dbContext.User.Find(Id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
            
        }

        public void AddUser(User user)
        {
            try
            {
                _dbContext.User.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void EditUser(User user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public User DeleteUser(int Id)
        {
            try
            {
                User? user = _dbContext.User.Find(Id);
                if (user != null)
                {
                    _dbContext.User.Remove(user);
                    _dbContext.SaveChanges();
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckUser(int Id)
        {
            return _dbContext.User.Any(e => e.Id == Id);
        }
    }
}
