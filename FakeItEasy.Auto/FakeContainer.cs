namespace FakeItEasy.Auto
{
    using System.Collections.Generic;

    internal class FakeContainer
    {
        private static readonly Dictionary<object, IEnumerable<object>> FakedParametersByObject = new Dictionary<object, IEnumerable<object>>();

        internal static void RegisterFakes(object autoFakedObject, IEnumerable<object> fakedParameters)
        {
            FakedParametersByObject.Add(autoFakedObject, fakedParameters);
        }

        internal static IEnumerable<object> GetFakesUsedBy(object autoFakedObject)
        {
            return FakedParametersByObject[autoFakedObject];
        }
    }
}