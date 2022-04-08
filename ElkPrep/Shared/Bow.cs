using System.ComponentModel.DataAnnotations.Schema;

namespace ElkPrep.Shared
{
    [Table("bows")]
    public class Bow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DrawLength { get; set; }
        public decimal DrawWeight { get; set; }
        public int LetOff { get; set; }
        public int FPS { get; set; }
        public int Range { get; set; }
        public Arrow? Arrow { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }



        //public Bow(string name, decimal drawLength, decimal drawWeight)
        //{
        //    Name = name;
        //    DrawLength = drawLength;
        //    DrawWeight = drawWeight;
        //}
    }
}