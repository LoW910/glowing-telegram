using ElkPrep.Server.DAL;
using ElkPrep.Server.Interfaces;
using ElkPrep.Shared;
using Microsoft.EntityFrameworkCore;

namespace ElkPrep.Server.Services
{
    public class BowService : IBow

    {
        readonly ElkPrepContext _dbContext = new();

        public BowService(ElkPrepContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBow(Bow bow)
        {
            try
            {
                bow.DateCreated = DateTime.Now;
                _dbContext.Bows.Add(bow);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to Add {bow.Name}");
            }
        }

        public void DeleteBow(int id)
        {
            try
            {
                Bow? bow = _dbContext.Bows.Find(id);
                if (bow != null)
                {
                    _dbContext.Bows.Remove(bow);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Delete Bow");
            }
        }

        public List<Bow> GetAllBows()
        {
            try
            {
                return _dbContext.Bows.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get a list of All bows");
                return null;
            }
        }

        public Bow GetBow(int id)
        {
            try
            {
                Bow? bow = _dbContext.Bows.Find(id);
                if (bow != null)
                {
                    return bow;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to get Bow Data");
                return null;
            }
        }

        public void UpdateBow(Bow bow)
        {
            try
            {
                bow.DateUpdated = DateTime.Now;
                _dbContext.Entry(bow).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Update Bow");
            }
        }
    }
}
