using Microsoft.Extensions.Caching.Distributed;

namespace CleanArch.eShop.Application.Common.Interfaces
{
    public interface IDistributedCacheService
    {
        Task<T?> GetFromCacheAsync<T>(string cacheKey) where T : class;
        Task SetCacheAsync<T>(string cacheKey, T value, DistributedCacheEntryOptions options) where T : class;
        Task ClearCacheAsync(string cacheKey);
    }
}
