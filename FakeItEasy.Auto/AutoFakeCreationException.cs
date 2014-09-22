namespace FakeItEasy.Auto
{
    using System;

    public class AutoFakeCreationException : Exception
    {
        public AutoFakeCreationException(string message) : base(message) {}
    }
}