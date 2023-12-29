using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CharityClinic.Data.Model
{
    public class GioiThieu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public int TitleId { get; set; }
        [Required]
        public string? Content { get; set; }
        public DateTime TimeCreate { get; set; }
    }
}
