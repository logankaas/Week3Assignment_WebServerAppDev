using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2_WebServerAppDev.Models
{
    [Table("Person")]
    public class Person
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

    }
}
