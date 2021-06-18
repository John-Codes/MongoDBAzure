using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Book> _books;
        public DbClient(IOptions<BookStoreDBConfig> bookstorecongifg)
        {
            var client = new MongoClient(bookstorecongifg.Value.Connection_String);
            var database = client.GetDatabase(bookstorecongifg.Value.Database_Name);
            _books = database.GetCollection<Book>(bookstorecongifg.Value.Books_COLLECTION_NAME);
        }
        public IMongoCollection<Book> GetBooksCollection() => _books;
    }
    public interface IDbClient
    {

        IMongoCollection<Book> GetBooksCollection();
    }

}
