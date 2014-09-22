namespace FakeItEasy.Auto.Tests.TestHelpers
{
    using FluentAssertions;
    using FluentAssertions.Execution;
    using FluentAssertions.Primitives;

    public static class ObjectAssertionsExtensions
    {
        public static AndConstraint<ObjectAssertions> BeFake<T>(this ObjectAssertions objectAssertions)
        {
            var subject = objectAssertions.Subject;
            if (subject == null)
            {
                Execute.Assertion.FailWith("Expected object to be a fake, but found <null>.");
                return null;
            }
            Execute.Assertion
                   .ForCondition(subject.GetType().FullName == "Castle.Proxies.ObjectProxy")
                   .FailWith("Expected object to be a fake, but found an actual {0}.", subject.GetType());
            var fakeObjectType = Fake.GetFakeManager(subject).FakeObjectType;
            Execute.Assertion
                   .ForCondition(fakeObjectType == typeof(T))
                   .FailWith("Expected object to be a fake {0}, but found a fake {1}.", typeof(T), fakeObjectType);
            return new AndConstraint<ObjectAssertions>(objectAssertions);
        }
    }
}