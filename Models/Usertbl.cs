using System.ComponentModel.DataAnnotations;

namespace XXMountainBrigadeNew.Models
{
    public class Usertbl
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        [Required]
        [MaxLength(100)]
        public string email { get; set; }
        [Required]
        [MaxLength(10)]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
