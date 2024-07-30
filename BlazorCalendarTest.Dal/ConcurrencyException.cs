using System;

namespace BlazorCalendarTest.Dal
{
    [Serializable]
    public class ConcurrencyException : Exception
    {
        public ConcurrencyException(string message) : base(message) { }
        public ConcurrencyException(string message, Exception inner) : base(message, inner) { }
    }
}