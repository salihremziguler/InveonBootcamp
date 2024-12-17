namespace AspNetCoreIdentityApp.Web.Models
{
    public class Book
    {

        public Book()
        {
            
        }

        public Book(int iD, string title, string author, string publicationYear, string iSBN, string genre, string publisher, int pageCount, string language, string summary, int avaliable)
        {
            Id = iD;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            ISBN = iSBN;
            Genre = genre;
            Publisher = publisher;
            PageCount = pageCount;
            Language = language;
            Summary = summary;
            AvaliableCopies = avaliable;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublicationYear { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
        public string Summary { get; set; }
        public int AvaliableCopies { get; set; }


    }
}
