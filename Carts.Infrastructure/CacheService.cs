using Carts.Domain.Abstraction;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Distributed;
namespace Carts.Infrastructure
{
    internal class CacheService : ICacheService
    {
        private readonly IDistributedCache? cache;
        public CacheService(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public void ClearCachedData(string key)
        {
            cache.Remove(key);
        }

        public T GetCachedData<T>(string key)
        {
            var data = cache.GetString(key);

            return data is null ? default : JsonConvert.DeserializeObject<T>(data);
        }

        public void SetCachedData<T>(string key, T data, TimeSpan cacheDuration)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = cacheDuration,
            };

            var jsonData = JsonConvert.SerializeObject(data);

            cache.SetString(key, jsonData, options);
        }
    }

}
