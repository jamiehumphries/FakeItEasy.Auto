namespace FakeItEasy.Auto.Tests
{
    using FakeItEasy.Auto.Tests.TestHelpers;
    using FakeItEasy.Auto.Tests.TestHelpers.Interfaces;
    using FakeItEasy.Auto.Tests.TestHelpers.Types;
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    public class TheFakeTests
    {
        [Test]
        public void Can_retrieve_faked_dependencies_on_auto_faked_object()
        {
            var foo = An.AutoFaked<Foo>();
            TheFake<IBar>.UsedBy(foo).Should().Be(foo.Bar).And.BeFake<IBar>();
        }

        [Test]
        public void Throws_exception_if_trying_to_retrieve_fakes_for_object_that_was_not_auto_faked()
        {
            // Given
            var foo = new Foo(A.Fake<IBar>());

            // When
            Action retrivingFakeBar = () => TheFake<IBar>.UsedBy(foo);

            // Then
            retrivingFakeBar.Should().Throw<FakeRetrievalException>().Which.Message.Should().Contain("was not auto faked");
        }

        [Test]
        public void Exception_thrown_if_no_fake_is_registered_for_type()
        {
            // Given
            var foo = An.AutoFaked<Foo>();

            // When
            Action retrievingBaz = () => TheFake<IBaz>.UsedBy(foo);

            // Then
            retrievingBaz.Should().Throw<FakeRetrievalException>().Which.Message.Should().Contain("did not use a fake of type");
        }
    }
}