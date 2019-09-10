using System;

namespace TechnicalRadiation.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileImgSource { get; set; }
        public string Bio { get; set; }
        public string ModifiedBy { get; set; } // code-generated
        public DateTime CreatedDate { get; set; } // code-generated
        public DateTime ModifiedDate { get; set; } //code-generated
    }
}