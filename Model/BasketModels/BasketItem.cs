using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Model.BasketModels
{
    public class BasketItem
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid ProductId { get; set; }
        [BsonRepresentation(BsonType.Int64)]
        public int Quantity { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
    }
}
