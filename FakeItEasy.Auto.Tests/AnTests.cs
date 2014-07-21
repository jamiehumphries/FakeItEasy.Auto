namespace FakeItEasy.Auto.Tests
{
    using FakeItEasy.Auto.Tests.TestTypes;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class AnTests
    {
        [Test]
        public void Can_auto_fake_object_with_no_dependencies()
        {
            An.AutoFaked<ObjectWithNoDependencies>().Should().BeOfType<ObjectWithNoDependencies>();
        }
    }
}