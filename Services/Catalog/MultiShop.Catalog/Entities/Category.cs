using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        //MongoDb ilişkisel veritabanı olmadığı için Id'ler string olarak tutuluyor.
        [BsonId]//MongoDb'de Id olduğunu belirtiyoruz.
        [BsonRepresentation(BsonType.ObjectId)]//Benzersiz bir Id olduğunu belirttik.
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
