namespace ElkPrep.Shared
{
    public class Broadhead
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Blades { get; set; }

        public Broadhead(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}