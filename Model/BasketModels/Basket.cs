using Model.Base;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Model.BasketModels
{
    public class Basket : BaseEntity
    {
        [BsonRepresentation(BsonType.String)]
        public string UserId { get; set; }
        public decimal TotalPayment { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

        public void CalculatePayment()
        {
            TotalPayment = BasketItems.Sum(x => x.Price * x.Quantity);
        }
    }
}
