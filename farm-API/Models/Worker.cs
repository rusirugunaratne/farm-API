using System.ComponentModel.DataAnnotations;

namespace farm_API.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Farm { get; set; }

        public string Position { get; set; }

        public string CertifiedUntil { get; set; }

        public string Image { get; set; }
    }
}
