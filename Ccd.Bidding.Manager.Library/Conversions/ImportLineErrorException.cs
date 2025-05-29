using System;

namespace Ccd.Bidding.Manager.Library.Conversions
{
   public class ImportLineErrorException : Exception
   {
      public ImportLineErrorException(string message) : base(message)
      {
      }
   }
}
