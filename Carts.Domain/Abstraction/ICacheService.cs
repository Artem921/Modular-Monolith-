namespace Carts.Domain.Abstraction
{
    internal interface ICacheService
    {
        T GetCachedData<T>(string key);
        void SetCachedData<T>(string key, T data, TimeSpan cacheDuration);
        void ClearCachedData(string key);
    }
}
