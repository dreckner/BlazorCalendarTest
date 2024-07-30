using System;

namespace BlazorCalendarTest.Dal
{
  [Serializable]
  public class UpdateFailureException : Exception
  {
    public UpdateFailureException(string message)
      : base(message)
    { }

    public UpdateFailureException(string message, Exception innerException)
      : base(message, innerException)
    { }
  }
}