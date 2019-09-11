using TechnicalRadiation.Models;

namespace TechnicalRadiation.Models.Dto
{
    public class AuthorDto : HyperMediaModel
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
}