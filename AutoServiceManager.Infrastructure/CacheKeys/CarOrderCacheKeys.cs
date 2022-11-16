namespace AutoServiceManager.Infrastructure.CacheKeys
{
    public static class CarOrderCacheKeys
    {
        public static string GetListKey(string roleName, string userId) => $"CarOrderList-{roleName}-{userId}";

        public static string SelectListKey => "CarOrderSelectList";

        public static string GetKey(int carOrderId, string roleName, string userId) => $"CarOrder-{roleName}-{carOrderId}-{userId}";

        public static string GetDetailsKey(int carOrderId, string roleName, string userId) => $"CarOrder-{roleName}-{carOrderId}-{userId}";
    }
}