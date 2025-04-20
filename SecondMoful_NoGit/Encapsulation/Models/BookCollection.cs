namespace Encapsulation.Models
{
    public class BookCollection
    {
		private string _bookTitle;

		public string BookTitle
		{
			get { return _bookTitle; }
			set { _bookTitle = value; }
		}
		private string _author;

		public string Author
		{
			get { return _author; }
			set { _author = value; }
		}
		public void AddBook(Book book)
		{
			
		}

	}
}
