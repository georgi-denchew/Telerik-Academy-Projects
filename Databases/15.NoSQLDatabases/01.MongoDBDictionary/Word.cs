using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _01.MongoDBDictionary
{
    public class Word
    {
        [BsonId]
        public ObjectId ID { get; set; }

        public string Name { get; set; }

        public string Translation { get; set; }

        [BsonConstructor]

        public Word(string name, string translation)
        {
            this.Name = name;
            this.Translation = translation;
        }
    }
}
