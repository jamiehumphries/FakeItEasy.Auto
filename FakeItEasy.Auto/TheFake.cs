namespace FakeItEasy.Auto
{
    using System.Linq;

    public class TheFake<T>
    {
        public static T UsedBy(object autoFakedObject)
        {
            var fakedParameters = FakeContainer.GetFakesUsedBy(autoFakedObject);
            return (T)fakedParameters.First(p => Fake.GetFakeManager(p).FakeObjectType == typeof(T));
        }
    }
}