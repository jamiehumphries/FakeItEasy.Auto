namespace FakeItEasy.Auto.Tests
{
    using FakeItEasy.Auto.Tests.TestHelpers.Interfaces;
    using FakeItEasy.Auto.Tests.TestHelpers.Types;
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class FakeContainerTests
    {
        [Test]
        public void Fakes_are_registered_weakly_and_so_NOT_eligible_for_garbage_collection()
        {
            // Given
            var foo = An.AutoFaked<Foo>();
            var bar = TheFake<IBar>.UsedBy(foo);

            // WeakReference Class Definition (https://docs.microsoft.com/en-us/dotnet/api/system.weakreference?view=netframework-4.8):
            // References an object while still allowing that object to be reclaimed by garbage collection.
            // If an object is reclaimed for garbage collection, a new data object is regenerated;
            // ...otherwise, the object is available to access because of the weak reference
            var weakReferenceToFoo = new WeakReference(foo);
            var weakReferenceToBar = new WeakReference(bar);

            // Then
            weakReferenceToFoo.Target.Should().Be(foo);
            weakReferenceToBar.Target.Should().Be(bar);

            // When
            foo = null;
            bar = null;
            GC.Collect();

            // Then
            weakReferenceToFoo.Target.Should().NotBe(foo);
            weakReferenceToBar.Target.Should().NotBe(bar);

            weakReferenceToFoo.Target.Should().NotBeNull();
            weakReferenceToBar.Target.Should().NotBeNull();
        }
    }
}