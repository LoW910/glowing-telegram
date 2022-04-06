using ElkPrep.Shared;
namespace ElkPrep.Server.Interfaces
{
    public interface IUser
    {
        public List<User> GetAllUsers();
        public void AddUser(User user);
        public void UpdateUser(User user);
        public User GetUser(int id);
        public void DeleteUser(int id);

    }
}
