using Obiddable.Win.UI.Bidding;
using Obiddable.Win.UI.Bidding.Navigation;

namespace Obiddable.Win.Library.UI;
public class FirstHostScreenResolver
{
   public HostScreen Resolve(IHostForm hostForm)
   {
      HostScreen output;

      output = new BidMaintenanceScreen(hostForm);
      if (isWorkingBidSet())
      {
         output = getWorkingBidNavigationScreen(hostForm);
      }

      return output;
   }

   private HostScreen getWorkingBidNavigationScreen(IHostForm hostForm)
   {
      HostScreen output;
      int workingBidId;

      workingBidId = UserConfiguration.Instance.WorkingBidId.Value;
      output = new BidNavigationScreen(hostForm, workingBidId);

      return output;
   }

   private bool isWorkingBidSet()
   {
      return UserConfiguration.Instance.WorkingBidId.HasValue;
   }
}
