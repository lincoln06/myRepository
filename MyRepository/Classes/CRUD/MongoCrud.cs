using MongoDB.Driver;
using MyRepository.Classes.Model;
using MyRepository.Interfaces;
using System.Linq;

namespace MyRepository.Classes.CRUD
{
    public class MongoCrud : ICrud
    {
        private readonly IMongoDatabase _db;
        private IMongoCollection<Book> _bookCollection;
        private IMongoCollection<User> _userCollection;
        public MongoCrud()
        {
            _db = new MongoClient().GetDatabase("Service");
            _userCollection = _db.GetCollection<User>("Users");
            _bookCollection = _db.GetCollection<Book>("Books");

        }

        public void AddABook(Book book)
        {
            _bookCollection.InsertOne(book);
        }

        public void AddUser(User user)
        {
            _userCollection.InsertOne(user);
        }

        public Book FindBook(string title)
        {
            var filter = Builders<Book>.Filter.Eq("Title", title);
            try
            {
                var record = _bookCollection.Find(filter).First();
                return record;
            }
            catch
            {
                return null;
            }
        }

        public User FindUser(string email, string password)
        {
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq("Email", email),
                Builders<User>.Filter.Eq("Password", password));
            try
            {
                var record = _userCollection.Find(filter).First();
                return record;
            }
            catch
            {
                return null;
            }
        }
    }
}
