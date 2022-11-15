namespace AutoServiceManager.Infrastructure.CacheKeys
{
    public static class CarOrderCacheKeys
    {
        public static string GetListKey(string userId) => $"CarOrderList-{userId}";

        public static string SelectListKey => "CarOrderSelectList";

        public static string GetKey(int carOrderId, string userId) => $"CarOrder-{carOrderId}-{userId}";

        public static string GetDetailsKey(int carOrderId, string userId) => $"CarOrder-{carOrderId}-{userId}";
    }
}