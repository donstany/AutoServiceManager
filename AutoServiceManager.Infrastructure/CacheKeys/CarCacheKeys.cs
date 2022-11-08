namespace AutoServiceManager.Infrastructure.CacheKeys
{
    public static class CarCacheKeys
    {
        public static string ListKey => "CarList";

        //TODO Stan - remove it is not usable
        public static string SelectListKey => "CarSelectList";

        public static string GetKey(int carId) => $"Car-{carId}";


        //TODO Stan - remove it is not usable
        public static string GetDetailsKey(int carId) => $"CarDetails-{carId}";
    }
}
