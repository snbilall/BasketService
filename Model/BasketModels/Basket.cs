using Model.Base;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Model.BasketModels
{
    public class Basket : BaseEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid UserId { get; set; }
        public List<BasketItem>? BasketItems { get; set; }
    }
}
