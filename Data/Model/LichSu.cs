using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CharityClinic.Data.Model
{
    public class LichSu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Year { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public int KindId { get; set; }
        public DateTime TimeCreate { get; set; }
    }
}
