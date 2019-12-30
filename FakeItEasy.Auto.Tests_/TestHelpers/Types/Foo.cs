namespace FakeItEasy.Auto.Tests.TestHelpers.Types
{
    using FakeItEasy.Auto.Tests.TestHelpers.Interfaces;

    public class Foo
    {
        public Foo(IBar bar)
        {
            Bar = bar;
        }

        public IBar Bar { get; set; }
    }
}