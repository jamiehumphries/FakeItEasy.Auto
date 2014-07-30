namespace FakeItEasy.Auto.Tests.TestHelpers
{
    using FluentAssertions;
    using FluentAssertions.Primitives;

    public static class ObjectAssertionsExtensions
    {
        public static AndConstraint<ObjectAssertions> BeFake(this ObjectAssertions objectAssertions)
        {
            objectAssertions.Subject.GetType().FullName.Should().Be("Castle.Proxies.ObjectProxy");
            return new AndConstraint<ObjectAssertions>(objectAssertions);
        }
    }
}