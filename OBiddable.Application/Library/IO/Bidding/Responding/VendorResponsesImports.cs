using System;
using System.IO;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Conversions.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Validations;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Win.UI;
using Ccd.Bidding.Manager.Win.UI.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;

namespace Ccd.Bidding.Manager.Win.Library.IO.Bidding.Responding
{
    public static class VendorResponsesImports
    {

        public static void ImportVendorResponseFromCSV(VendorResponse vendorResponse, IRespondingRepo respondingRepo, CatalogingService catalogingService)
        {
            string fileName = FileHelpers.OpenFile("Open Vendor Response Import", "csv");
            if (fileName is null)
            {
                return;
            }
            string errors = "";
            VendorResponse vr = File.ReadAllLines(fileName).ConvertCSVToVendorResponse(vendorResponse.Bid.Id, out errors, catalogingService);
            if (errors != "")
            {
                FormsMessaging.Instance.ShowImportError(errors);
            }
            if (vr is null || vr.ResponseItems.Count == 0)
            {
                FormsMessaging.Instance.ShowImportNotCompleted();
                return;
            }
            try
            {
                vr.ResponseItems.ForEach(x => respondingRepo.AddResponseItem_ToVendorResponse(x, vendorResponse.Id));
                VendorResponseMessaging.Instance.ShowResponseItemsImportSuccess(vr.ResponseItems);
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
        public static void ImportVendorResponseFromExcel(VendorResponse vendorResponse, IRespondingRepo respondingRepo, CatalogingService catalogingService)
        {
            string fileName = FileHelpers.OpenFile("Open Vendor Response Import", "xlsx");
            if (fileName is null)
            {
                return;
            }

            string errors = "";
            FileInfo file = new FileInfo(fileName);
            VendorResponse vr = VendorResponsesConversions.ConvertExcelFileToVendorResponse(file, vendorResponse.Bid.Id, out errors, catalogingService);

            if (errors != "")
            {
                FormsMessaging.Instance.ShowImportError(errors);
            }

            if (vr is null || vr.ResponseItems.Count == 0)
            {
                FormsMessaging.Instance.ShowImportNotCompleted();
                return;
            }
            try
            {
                vr.ResponseItems.ForEach(x => respondingRepo.AddResponseItem_ToVendorResponse(x, vendorResponse.Id));

                VendorResponseMessaging.Instance.ShowResponseItemsImportSuccess(vr.ResponseItems);
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
