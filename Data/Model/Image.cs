using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CharityClinic.Data.Model
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? PathImg { get; set; }
        [Required]
        public string? Title { get; set; }
        public DateTime TimeCreate { get; set; }
        [ForeignKey("DanhMucImage")]
        public int DanhMucImageId { get; set; }
        public virtual DanhMucImage DanhMucImage { get; set; }
    }
}
