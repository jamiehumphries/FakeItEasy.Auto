namespace FakeItEasy.Auto.Tests
{
    using FakeItEasy.Auto.Tests.TestHelpers;
    using FakeItEasy.Auto.Tests.TestHelpers.Types;
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

        [Test]
        public void Can_auto_fake_object_with_fakeable_dependencies()
        {
            An.AutoFaked<ObjectWithFakeableDependencies>().Should().BeOfType<ObjectWithFakeableDependencies>();
        }

        [Test]
        public void Auto_faked_dependencies_are_fakes()
        {
            An.AutoFaked<Foo>().Bar.Should().BeFake();
        }
    }
}