using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CharityClinic.Data.Model
{
    public class SlideImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? PathImg { get; set; }
        public DateTime TimeCreate { get; set; }
    }
}
