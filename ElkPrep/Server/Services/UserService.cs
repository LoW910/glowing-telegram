using ElkPrep.Server.DAL;
using ElkPrep.Server.Interface;
using ElkPrep.Shared;
using Microsoft.EntityFrameworkCore;

namespace ElkPrep.Server.Services
{
    public class UserService : IUser
    {

        readonly ElkPrepContext _dbContext = new();
        public UserService(ElkPrepContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            try
            {
                user.DateCreated = DateTime.Now;
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to Add {user.FirstName} User");
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                // trys to find the user id
                User? user = _dbContext.Users.Find(id);
                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    _dbContext.SaveChanges();
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to Remove {id} User");
            }
        }

        public User GetUserData(int id)
        {
            try
            {
                User? user = _dbContext.Users.Find(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failled to Get User Data!");
                return null;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _dbContext.Users.ToList();
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get User Details");
                return null;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                user.DateUpdated = DateTime.Now;
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed to Update {user.FirstName} User");
            }
        }
    }
}
