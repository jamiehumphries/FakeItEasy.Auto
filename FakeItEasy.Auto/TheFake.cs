namespace FakeItEasy.Auto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TheFake<T>
    {
        public static T UsedBy(object autoFakedObject)
        {
            if (autoFakedObject == null)
            {
                throw new ArgumentNullException("autoFakedObject");
            }
            var fakedParameters = GetFakesUsedBy(autoFakedObject);
            return (T)fakedParameters.First(p => Fake.GetFakeManager(p).FakeObjectType == typeof(T));
        }

        private static IEnumerable<object> GetFakesUsedBy(object autoFakedObject)
        {
            var fakes = FakeContainer.GetFakesUsedBy(autoFakedObject);
            if (fakes == null)
            {
                var message = String.Format("This object was not auto faked. Expected usage is:\r\n{0}", ExpectedUsage(autoFakedObject));
                throw new FakeRetrievalException(message);
            }
            return fakes;
        }

        private static object ExpectedUsage(object autoFakedObject)
        {
            var autoFakedType = autoFakedObject.GetType();
            var requestedType = typeof(T);
            const string usageFormat = "    var {0} = An.AutoFaked<{1}>();\r\n" +
                                       "    var {2} = TheFake<{3}>.UsedBy({0});";
            return String.Format(usageFormat, VariableName(autoFakedType), autoFakedType.Name, VariableName(requestedType), requestedType.Name);
        }

        private static string VariableName(Type type)
        {
            var typeName = type.Name;
            if (typeName[0] == 'I' && type.IsInterface)
            {
                typeName = typeName.Substring(1);
            }
            return Char.ToLowerInvariant(typeName[0]) + typeName.Substring(1);
        }
    }
}