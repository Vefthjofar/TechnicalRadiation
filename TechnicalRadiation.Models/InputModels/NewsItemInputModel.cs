using System.ComponentModel.DataAnnotations;

namespace TechnicalRadiation.Models.InputModels
{
    public class NewsItemInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required] // must be valid url
        [Url]
        public string ImgSource { get; set; }
        [Required]
        [MinLength(0)]
        [MaxLength(50)]
        public string ShortDescription { get; set; }

        [Required]
        [MinLength(50)]
        [MaxLength(255)]
        public string LongDescription { get; set; }
        [Required]
        public string PublishDate { get; set; }
    }
}