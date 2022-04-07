using ElkPrep.Shared;

namespace ElkPrep.Server.Interfaces
{
    public interface IArrow
    {
        public List<Arrow> GetAllArrows();
        public void AddArrow(Arrow arrow);
        public void UpdateArrow(Arrow arrow);
        public Arrow GetArrow(int id);
        public void DeleteArrow(int id);
    }
}
