namespace FakeItEasy.Auto.Tests
{
    using FakeItEasy.Auto.Tests.TestHelpers;
    using FakeItEasy.Auto.Tests.TestHelpers.Interfaces;
    using FakeItEasy.Auto.Tests.TestHelpers.Types;
    using FluentAssertions;
    using NUnit.Framework;
    using System;

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
            An.AutoFaked<Foo>().Bar.Should().BeFake<IBar>();
        }

        [Test]
        public void Constructor_with_most_parameters_is_preferred()
        {
            An.AutoFaked<ObjectWithMultipleConstructors>().WasMadeFromConstructorWithMostParameters.Should().BeTrue();
        }

        [Test]
        public void Throws_exception_if_type_has_no_public_constructor()
        {
            // When
            Action autoFakingObjectWithNoPublicConstructor = () => An.AutoFaked<ObjectWithNoPublicConstructor>();

            // Then
            autoFakingObjectWithNoPublicConstructor.Should().Throw<AutoFakeCreationException>().Which.Message.Should().Contain("no public constructor");
        }

        [Test]
        public void Throws_exception_if_parameters_cannot_be_faked()
        {
            // When
            Action autoFakingObjectWithUnfakeableDependencies = () => An.AutoFaked<ObjectWithUnfakeableDependencies>();

            // Then
            autoFakingObjectWithUnfakeableDependencies.Should().Throw<AutoFakeCreationException>().Which.Message.Should().Contain("no constructor had parameters that were all fakeable");
        }
    }
}