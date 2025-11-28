
namespace Libreria.Models
{
    //Class representing a book in the library
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public string GetPrizeToString() => Price.ToString("0.00");
    }
}
