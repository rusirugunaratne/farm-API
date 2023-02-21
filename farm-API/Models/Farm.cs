using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farm_API.Models
{
    public class Farm
    {
        [Key]
        public int FarmId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string FarmName { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string Image { get; set; }

        public bool HasBarge { get; set; }
    }
}
