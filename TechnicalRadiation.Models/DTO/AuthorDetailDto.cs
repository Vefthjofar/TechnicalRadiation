using TechnicalRadiation.Models.HyperMedia;

namespace TechnicalRadiation.Models.Dto
{
    public class AuthorDetailDto : HyperMediaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileImgSource { get; set; }
        public string Bio { get; set; }
    }
}