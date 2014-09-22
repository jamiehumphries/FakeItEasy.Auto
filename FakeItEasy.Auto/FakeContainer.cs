namespace FakeItEasy.Auto
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    internal class FakeContainer
    {
        private static readonly ConditionalWeakTable<object, IEnumerable<object>> FakedParametersByObject = new ConditionalWeakTable<object, IEnumerable<object>>();

        internal static void RegisterFakes(object autoFakedObject, IEnumerable<object> fakedParameters)
        {
            FakedParametersByObject.Add(autoFakedObject, fakedParameters);
        }

        internal static IEnumerable<object> GetFakesUsedBy(object autoFakedObject)
        {
            IEnumerable<object> fakes;
            FakedParametersByObject.TryGetValue(autoFakedObject, out fakes);
            return fakes;
        }
    }
}