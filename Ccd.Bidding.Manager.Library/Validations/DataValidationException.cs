using System;

namespace Ccd.Bidding.Manager.Library.Validations
{
   public class DataValidationException : Exception
   {
      public DataValidationException(string message) : base(message) { }
   }
}
