namespace AutoServiceManager.Infrastructure.CacheKeys
{
    public static class CarCacheKeys
    {
        public static string ListKey => "CarList";

        public static string GetKey(int carId) => $"Car-{carId}";

    }
}
