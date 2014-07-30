namespace FakeItEasy.Auto
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class An
    {
        private static readonly MethodInfo FakeMethod = typeof(A).GetMethod("Fake", new Type[0]);

        public static T AutoFaked<T>()
        {
            var constructor = typeof(T).GetConstructors().First();
            var paramaters = constructor.GetParameters().Select(p => Fake(p.ParameterType));
            return (T)constructor.Invoke(paramaters.ToArray());
        }

        private static object Fake(Type parameterType)
        {
            return FakeMethod.MakeGenericMethod(parameterType).Invoke(null, null);
        }
    }
}