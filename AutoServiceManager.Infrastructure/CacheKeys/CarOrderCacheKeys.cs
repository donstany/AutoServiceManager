namespace AutoServiceManager.Infrastructure.CacheKeys
{
    public static class CarOrderCacheKeys
    {
        public static string ListKey => "CarOrderList";

        public static string SelectListKey => "CarOrderSelectList";

        public static string GetKey(int carOrderId) => $"CarOrder-{carOrderId}";

        public static string GetDetailsKey(int carOrderId) => $"CarOrder-{carOrderId}";
    }
}