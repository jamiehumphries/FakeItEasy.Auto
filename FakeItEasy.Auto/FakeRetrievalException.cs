namespace FakeItEasy.Auto
{
    using System;

    public class FakeRetrievalException : Exception
    {
        public FakeRetrievalException(string message) : base(message) {}
    }
}