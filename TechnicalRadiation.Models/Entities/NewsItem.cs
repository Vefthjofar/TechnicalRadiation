namespace TechnicalRadiation.Models.Entities
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgSource { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string PublishDate { get; set; }
        public string ModifiedBy { get; set; } // code-generated
        public string CreatedDate { get; set; } // code-generated
        public string ModifiedDate { get; set; } //code-generated
    }
}