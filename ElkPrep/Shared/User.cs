using System.ComponentModel.DataAnnotations.Schema;

namespace ElkPrep.Shared
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
        List<Arrow> Arrows { get; set; }
        List<Bow> Bows { get; set; }
        List<Target> Targets { get; set; }


        //public User(string firstName, string lastName, int age)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Age = age;
        //}


    }

}
