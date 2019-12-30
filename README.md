[![Build status](https://ci.appveyor.com/api/projects/status/h2iirqumti2wfd22/branch/master?svg=true)](https://ci.appveyor.com/project/jamiehumphries/fakeiteasy-auto/branch/master)

## Migrated to .NetStandard 2.0

####Example

```csharp
using FakeItEasy;
using FakeItEasy.Auto;
using NUnit.Framework;

public interface IBar
{
    void DoSomething();
}

public class Foo
{
    private readonly IBar bar;

    public Foo(IBar bar)
    {
        this.bar = bar;
    }

    public void MakeBarDoSomething()
    {
        bar.DoSomething();
    }
}

public class FooTests
{
    [Test]
    public void Can_make_bar_do_something()
    {
        // Given
        var foo = An.AutoFaked<Foo>();
        var bar = TheFake<IBar>.UsedBy(foo);
        
        // When
        foo.MakeBarDoSomething();
        
        // Then
        A.CallTo(() => bar.DoSomething()).MustHaveHappened();
    }
}
```
