namespace FakeItEasy.Auto
{
    using System.Linq;

    public static class An
    {
        public static T AutoFaked<T>()
        {
            var constructor = typeof(T).GetConstructors().First();
            var paramaters = constructor.GetParameters().Select(p => Fake());
            return (T)constructor.Invoke(paramaters.ToArray());
        }

        private static object Fake()
        {
            return null;
        }
    }
}