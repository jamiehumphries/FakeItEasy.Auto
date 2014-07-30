##Example

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
            var foo = An.AutoFaked<Foo>();
            foo.MakeBarDoSomething();
            A.CallTo(() => TheFake<IBar>.UsedBy(foo).DoSomething()).MustHaveHappened();
        }
    }
