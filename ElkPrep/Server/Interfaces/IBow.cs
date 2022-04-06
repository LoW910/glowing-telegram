using ElkPrep.Shared;

namespace ElkPrep.Server.Interfaces
{
    public interface IBow
    {
        public List<Bow> GetAllBows();
        public void AddBow(Bow bow);
        public void UpdateBow(Bow bow);
        public Bow GetBow(int id);
        public void DeleteBow(int id);
    }
}
