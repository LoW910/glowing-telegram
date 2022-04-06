using ElkPrep.Server.DAL;
using ElkPrep.Server.Interfaces;
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
                Console.WriteLine($"Failed to Add User");
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
                Console.WriteLine($"Failed to Remove User");
            }
        }

        public User GetUser(int id)
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
                Console.WriteLine("Failled to Get User!");
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
                Console.WriteLine("Failed to Get all Users");
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
                Console.WriteLine("Failed to Update User");
            }
        }
    }
}
