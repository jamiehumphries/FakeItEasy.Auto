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
        public void Fakes_are_registered_weakly_and_so_eligible_for_garbage_collection()
        {
            // Given
            var foo = An.AutoFaked<Foo>();
            var bar = TheFake<IBar>.UsedBy(foo);
            var weakReferenceToFoo = new WeakReference(foo);
            var weakReferenceToBar = new WeakReference(bar);

            // When
            // ReSharper disable RedundantAssignment
            foo = null;
            bar = null;
            // ReSharper restore RedundantAssignment
            GC.Collect();

            // Then
            weakReferenceToFoo.Target.Should().BeNull();
            weakReferenceToBar.Target.Should().BeNull();
        }
    }
}