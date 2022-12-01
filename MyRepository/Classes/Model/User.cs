using MongoDB.Bson.Serialization.Attributes;
using MyRepository.Classes.Validation;
using MyRepository.Interfaces;

namespace MyRepository.Classes.Model
{
    [BsonIgnoreExtraElements]
    public class User:Item, IElement
    {
        [BsonElement]
        public string Email { get; }
        [BsonElement]
        public string Password { get; private set; }
        public User(string firstName, string lastName, string email, string password)
            : base(firstName, lastName)
        {
            Email = email;
            Password = password;
        }

        public void Validate()
        {
            UserValidator validator = new UserValidator();
            var result = validator.Validate(this);
            IsValid = result.IsValid;
        }
    }
}
