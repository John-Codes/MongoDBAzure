using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core
{
    public class BookServices : IBookServices
    {
        private readonly IMongoCollection<Book> _books;
        public BookServices(IDbClient dbClient)
        {
           _books= dbClient.GetBooksCollection();
        }

        public Book AddBook(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void DeleteBook(string id)
        {
            _books.DeleteOne(Book => Book.id == id);
        }

        public Book GetBook(string id) => _books.Find(book => book.id == id).First();

        public List<Book> GetBooks() => _books.Find(book => true).ToList();

        public Book UppdateBook(Book book)
        {
            GetBook(book.id);
            _books.ReplaceOne(b => b.id == book.id, book);
            return book;
        }
    }
    public interface IBookServices
    {
        List<Book> GetBooks();
        Book GetBook(string id);
        Book AddBook(Book book);
        void DeleteBook(string id);

        Book UppdateBook(Book book);


    }


}
