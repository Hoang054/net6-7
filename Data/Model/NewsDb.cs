using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CharityClinic.Data.Model
{
    public class NewsDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Tiltle { get; set; }
        [Required]
        public string? Content { get; set; }
        public string? PathImg { get; set; }
        public DateTime TimeCreate { get; set; }
    }
}
