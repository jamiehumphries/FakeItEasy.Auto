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
            var fakedParameters = constructor.GetParameters().Select(p => Fake(p.ParameterType)).ToArray();
            var autoFakedObject = (T)constructor.Invoke(fakedParameters);
            FakeContainer.RegisterFakes(autoFakedObject, fakedParameters);
            return autoFakedObject;
        }

        private static object Fake(Type parameterType)
        {
            return FakeMethod.MakeGenericMethod(parameterType).Invoke(null, null);
        }
    }
}