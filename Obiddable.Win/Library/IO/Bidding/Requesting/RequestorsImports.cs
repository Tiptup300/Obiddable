using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Requesting;
using Obiddable.Library.Conversions.Bidding.Requesting;
using Obiddable.Library.Validations;
using Obiddable.Win.UI;
using Obiddable.Win.UI.Bidding.Requesting;

namespace Obiddable.Win.Library.IO.Bidding.Requesting;
public static class RequestorsImports
{
   public static void ImportRequestorsFromCSV(Bid bid, IRequestingRepo requestingRepo)
   {
      string fileName = FileHelpers.OpenFile("Open Requestors Import", "csv");
      if (fileName is null)
      {
         return;
      }

      string errors = "";
      List<Requestor> requestors = File.ReadAllLines(fileName).ConvertCSVToRequestors(out errors);

      if (errors != "")
      {
         FormsMessaging.Instance.ShowImportError(errors);
      }

      if (requestors is null || requestors.Count == 0)
      {
         FormsMessaging.Instance.ShowImportNotCompleted();
         return;
      }

      try
      {
         foreach (var requestor in requestors)
         {
            var requests = requestor.Requests;
            requestor.Requests = null;

            requestingRepo.AddRequestor_ToBid(requestor, bid.Id);

            requests.ForEach(x => requestingRepo.AddRequest_ToRequestor(x, requestor.Id));
         }
         RequestorMessaging.Instance.ShowRequestorImportSuccess(requestors);
      }
      catch (DataValidationException e)
      {
         FormsMessaging.Instance.ShowDataValidationExceptionError(e);
      }
      catch (Exception e)
      {
         FormsMessaging.Instance.ShowDatabaseOperationError(e.Message);
      }
   }
}
