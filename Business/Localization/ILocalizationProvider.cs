namespace Business.Localization
{
    public interface ILocalizationProvider
    {
        Task<string> GetLocalization(string key, string language);
    }
}
