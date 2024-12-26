namespace BP215API.Extensions
{
    public static class IQueryableExtension
    {
        public static  IQueryable<T>Random<T>(this IQueryable<T> query , int RandomNumber)
        {
            Random random = new Random();
            int num = random.Next(0,RandomNumber);
            return query.Skip(num);
        }
    }
}
