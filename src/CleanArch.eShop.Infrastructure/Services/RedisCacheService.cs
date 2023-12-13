using CleanArch.eShop.Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CleanArch.eShop.Infrastructure.Services
{
    public class RedisCacheService(IDistributedCache cache) : IDistributedCacheService
    {
        public async Task ClearCacheAsync(string cacheKey)
        {
            await cache.RemoveAsync(cacheKey);
        }

        public async Task<T?> GetFromCacheAsync<T>(string cacheKey) where T: class
        {
            var cacheItem = await cache.GetStringAsync(cacheKey);
            
            return cacheItem is null ? null : JsonSerializer.Deserialize<T>(cacheItem);
        }

        public async Task SetCacheAsync<T>(string cacheKey, T value, DistributedCacheEntryOptions options) where T : class
        {
            var response = JsonSerializer.Serialize(value);
            
            await cache.SetStringAsync(cacheKey, response, options);
        }
    }
}
