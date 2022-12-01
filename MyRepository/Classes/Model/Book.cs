using MongoDB.Bson.Serialization.Attributes;
using MyRepository.Interfaces;
using MyRepository.Classes.Model;

namespace MyRepository.Classes
{
    [BsonIgnoreExtraElements]
    public class Book : Item, IElement
    {
        [BsonElement]
        public string Title { get; }
        [BsonElement]
        public string Genre { get; }
        [BsonElement]
        public ushort Year { get; }
        public Book(string firstName, string lastName, string title, string genre, ushort year)
            : base(firstName, lastName)
        {
            Title = title;
            Genre = genre;
            Year = year;
        }

        public void Validate()
        {
            BookValidator validator = new BookValidator();
            var result = validator.Validate(this);
            IsValid = result.IsValid;
        }
    }
}