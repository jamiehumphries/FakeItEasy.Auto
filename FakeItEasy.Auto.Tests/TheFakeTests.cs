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
        public void Can_retrieve_faked_dependencies_on_autofaked_object()
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
            retrivingFakeBar.ShouldThrow<FakeRetrievalException>().Which.Message.Should().Contain("was not auto faked");
        }
    }
}