namespace Business.Localization
{
    public class LocalizationProvider : ILocalizationProvider
    {
        private readonly Dictionary<string, string> localizationMap = new Dictionary<string, string>
        {
            { "UnknownException", "Bilinmeyen hata oluştu!" },
            { "ValidationException", "İstek parametrelerini kontrol ediniz!" },
            { "BusinessBaseException_10", "Bilinmeyen hata oluştu!" },
            { "BusinessBaseException_50", "Sepete eklemeye çalıştığınız ürün bulunamadı!" },
            { "BusinessBaseException_51", "Sepete eklemeye çalıştığınız ürünün yeterli stoğu yok!" },
            { "BusinessBaseException_100", "Sepet bulunamadı!" },
            { "BusinessBaseException_101", "Ürün sepet içinde bulunamadı!" },
            { "BusinessBaseException_102", "Sepetten çıkarmaya çalıştığınız ürün sayısı sepetteki ürün sayısından fazla olamaz!" }
        };

        public Task<string> GetLocalization(string key, string language)
        {
            return Task.FromResult(localizationMap[key]);
        }
    }
}
