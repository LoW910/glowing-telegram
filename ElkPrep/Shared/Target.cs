namespace ElkPrep.Shared
{
    public class Target
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal VitalSize { get; set; }
        public int Points { get; set; }
        //public User User { get; set; }
        public Shot? Shot { get; set; }

        //public Target(string name, decimal width, decimal length)
        //{
        //    Name = name;
        //    Width = width;
        //    Length = length;
        //}


    }
}