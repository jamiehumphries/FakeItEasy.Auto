namespace FakeItEasy.Auto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class An
    {
        private static readonly MethodInfo FakeMethod = typeof(A).GetMethod("Fake", new Type[0]);

        public static T AutoFaked<T>()
        {
            var constructors = GetPublicConstructors<T>().OrderByDescending(ctor => ctor.GetParameters().Count());
            foreach (var constructor in constructors)
            {
                try
                {
                    return AutoFakeFromConstructor<T>(constructor);
                }
                catch (TargetInvocationException) { }
                catch (ArgumentException) { }
            }
            var message = String.Format("Failed to auto fake the type {0} because no constructor had parameters that were all fakeable.", typeof(T));
            throw new AutoFakeCreationException(message);
        }

        private static IEnumerable<ConstructorInfo> GetPublicConstructors<T>()
        {
            var constructors = typeof(T).GetConstructors();
            if (!constructors.Any())
            {
                var message = String.Format("Failed to auto fake the type {0} because it has no public constructor.", typeof(T));
                throw new AutoFakeCreationException(message);
            }
            return constructors;
        }

        private static T AutoFakeFromConstructor<T>(ConstructorInfo constructor)
        {
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