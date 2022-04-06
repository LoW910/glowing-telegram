using System.ComponentModel.DataAnnotations.Schema;

namespace ElkPrep.Shared
{
    [Table("arrows")]
    public class Arrow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fletch { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public string Broadhead { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }


        //public Arrow(int weight, int length, string broadhead)
        //{
        //    Weight = weight;
        //    Length = length;
        //    Broadhead = broadhead;
        //}

    }
}