namespace FakeItEasy.Auto.Tests
{
    using FakeItEasy.Auto.Tests.TestHelpers;
    using FakeItEasy.Auto.Tests.TestHelpers.Interfaces;
    using FakeItEasy.Auto.Tests.TestHelpers.Types;
    using FluentAssertions;
    using NUnit.Framework;

    public class TheFakeTests
    {
        [Test]
        public void Can_retrieve_faked_dependencies_on_autofaked_object()
        {
            var foo = An.AutoFaked<Foo>();
            TheFake<IBar>.UsedBy(foo).Should().Be(foo.Bar).And.BeFake<IBar>();
        }
    }
}