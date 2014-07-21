namespace FakeItEasy.Auto
{
    using System;

    public static class An
    {
        public static T AutoFaked<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}