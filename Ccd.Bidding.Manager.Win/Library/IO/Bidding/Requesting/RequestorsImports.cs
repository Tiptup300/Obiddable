using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Conversions.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Validations;
using Ccd.Bidding.Manager.Win.UI;
using Ccd.Bidding.Manager.Win.UI.Bidding.Requesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ccd.Bidding.Manager.Win.Library.IO.Bidding.Requesting
{
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
}
