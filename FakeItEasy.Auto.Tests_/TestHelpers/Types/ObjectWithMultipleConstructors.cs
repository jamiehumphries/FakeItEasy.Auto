namespace FakeItEasy.Auto.Tests.TestHelpers.Types
{
    using FakeItEasy.Auto.Tests.TestHelpers.Interfaces;

    public class ObjectWithMultipleConstructors
    {
        public ObjectWithMultipleConstructors() {}

        // ReSharper disable once UnusedParameter.Local
        public ObjectWithMultipleConstructors(IBar bar)
        {
            WasMadeFromConstructorWithMostParameters = true;
        }

        public bool WasMadeFromConstructorWithMostParameters { get; private set; }
    }
}