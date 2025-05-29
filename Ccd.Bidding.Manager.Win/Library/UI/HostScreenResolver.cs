using System;

namespace Ccd.Bidding.Manager.Win.Library.UI
{
   public class HostScreenResolver
   {
      public HostScreen Resolve<TScreen>() where TScreen : HostScreen
      {
         HostScreen output;

         output = (HostScreen)Activator.CreateInstance<TScreen>();

         return output;
      }
   }
}
