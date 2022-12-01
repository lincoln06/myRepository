using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRepository.Classes.Model
{
    [BsonIgnoreExtraElements]
    public abstract class Item
    {
        [BsonElement]
        public string FirstName { get; }
        [BsonElement]
        public string LastName { get; }
        [BsonIgnore]
        public bool IsValid { get; set; }
        private void Validate() { }
        public Item(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            IsValid = false;
        }
    }
}
