using System;
using System.IO;
using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Win.Library.IO;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Win.UI;
using Ccd.Bidding.Manager.Win.UI.Bidding.Requesting;
using OBiddable.Library.Bidding.Cataloging;
using OBiddable.Library.Bidding.Requesting;
using OBiddable.Library.Validations;
using OBiddable.Library.Conversions.Bidding.Requesting;

namespace Ccd.Bidding.Manager.Win.Library.IO.Bidding.Requesting
{
    public static class RequestsImports
    {
        public static void ImportRequestFromCSV(Request request, CatalogingService catalogingService, IRequestingRepo requestingRepo)
        {
            string fileName = FileHelpers.OpenFile("Open Request Import", "csv");
            if (fileName is null)
            {
                return;
            }

            string errors = "";
            Request r = File.ReadAllLines(fileName).ConvertCSVToRequest(request.Requestor.Bid.Id, out errors, catalogingService);

            if (errors != "")
            {
                FormsMessaging.Instance.ShowImportError(errors);
            }

            if (r is null || r.RequestItems.Count == 0)
            {
                FormsMessaging.Instance.ShowImportNotCompleted();
                return;
            }
            try
            {
                r.RequestItems.ForEach(x => requestingRepo.AddRequestItem_ToRequest(x, request.Id));
                RequestMessaging.Instance.ShowRequestImportSuccess(r);
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
        public static void ImportRequestFromExcel(Request request, CatalogingService catalogingService, IRequestingRepo requestingRepo)
        {
            string fileName = FileHelpers.OpenFile("Open Request Import", "xlsx");
            if (fileName is null)
            {
                return;
            }

            string errors = "";
            FileInfo file = new FileInfo(fileName);
            Request r = RequestsConversions.ConvertExcelFileToRequest(file, request.Requestor.Bid.Id, request.Requestor.Password, out errors, catalogingService);

            if (errors != "")
            {
                FormsMessaging.Instance.ShowImportError(errors);
            }

            if (r is null || r.RequestItems.Count == 0)
            {
                FormsMessaging.Instance.ShowImportNotCompleted();
                return;
            }

            try
            {
                r.RequestItems.ForEach(x => requestingRepo.AddRequestItem_ToRequest(x, request.Id));
                RequestMessaging.Instance.ShowRequestImportSuccess(r);
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
