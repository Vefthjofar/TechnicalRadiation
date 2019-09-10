using System.ComponentModel.DataAnnotations;

namespace TechnicalRadiation.Models.InputModels
{
    public class AuthorInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Url] // must be valid url
        public string ProfileImgSource { get; set; }
        [MaxLength(255)]
        public string bio { get; set; }

    }
}