using DataLayer.RespositoryBase;
using Model.BasketModels;

namespace DataLayer.Repositories
{
    public class BasketRepository : MongoRepositoryBase<IMongoDbContext, Basket>, IBasketRepository
    {
        public BasketRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
