using ElkPrep.Server.DAL;
using ElkPrep.Server.Interfaces;
using ElkPrep.Shared;
using Microsoft.EntityFrameworkCore;

namespace ElkPrep.Server.Services
{
    public class ArrowService : IArrow
    {

        readonly ElkPrepContext _dbContext = new();

        public ArrowService(ElkPrepContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddArrow(Arrow arrow)
        {
            try
            {
                arrow.DateCreated = DateTime.Now;
                _dbContext.Arrows.Add(arrow);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Add User");
            }
        }

        public void DeleteArrow(int id)
        {
            try
            {
                Arrow? arrow = _dbContext.Arrows.Find(id);
                if (arrow != null)
                {
                    _dbContext.Arrows.Remove(arrow);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Remove Arrow");
            }
        }

        public List<Arrow> GetAllArrows()
        {
            try
            {
                return _dbContext.Arrows.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Get all Arrows");
                return null;
            }
        }

        public Arrow GetArrow(int id)
        {
            try
            {
                Arrow? arrow = _dbContext.Arrows.Find(id);
                if(arrow != null)
                {
                    return arrow;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Get Arrow");
                return null;
            }
        }

        public void UpdateArrow(Arrow arrow)
        {
            try
            {
                arrow.DateUpdated = DateTime.Now;
                _dbContext.Entry(arrow).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed to Update Arrow");
            }
        }
    }
}
