using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2_WebServerAppDev.Models
{
    [Table("Hobbies")]
    public class Hobbies
    {
        public int HobbiesId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FavoriteHobby { get; set; }
    }
}
