using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System.Text;

namespace Ccd.Bidding.Manager.Library.Conversions.Bidding.Electing;
public class ElectionsConversions
{
   private readonly ICatalogingRepo _catalogingRepo;
   private readonly IRespondingRepo _respondingRepo;

   public ElectionsConversions(ICatalogingRepo catalogingRepo, IRespondingRepo respondingRepo)
   {
      _catalogingRepo = catalogingRepo;
      _respondingRepo = respondingRepo;
   }

   private const string _electionCSVHeader = "itemcode,vendorname,electionreason";
   public List<ResponseItem> ConvertCSVToElections(string[] fileData, int bidId, out string error)
   {
      StringBuilder err = new StringBuilder();
      List<ResponseItem> output = new List<ResponseItem>();

      if (fileData[0].ToLower().Trim() != _electionCSVHeader)
      {
         err.AppendLine($"fatal error: file header does not match");
         error = err.ToString();
         return null;
      }

      List<VendorResponse> vendorResponses = _respondingRepo.GetVendorResponses_ByBid(bidId);
      List<Item> items = _catalogingRepo.GetItems(bidId)
          .ToList();

      for (int x = 1; x < fileData.Length; x++)
      {
         if (fileData[x].Trim() == "")
         {
            err.AppendLine($"line skip: line blank ( line:{x} )");
            continue;
         }

         string[] flds = fileData[x].ParseCSVRow();

         // Get Item
         int itemCode = 0;
         if (!int.TryParse(flds[0], out itemCode))
         {
            err.AppendLine($"line skip: itemCode invalid ( line:{x} )");
            continue;
         }
         if (output.Any(q => q.Item.Code == itemCode))
         {
            err.AppendLine($"line skip: item code already used ( line:{x},itemCode:{itemCode} )");
            continue;

         }
         Item item = items.SingleOrDefault(q => q.Code == itemCode);
         if (item is null)
         {
            err.AppendLine($"line skip: item code not found ( line:{x},itemCode:{itemCode} )");
            continue;
         }


         // Get Vendor Response
         string vendorName = flds[1];
         VendorResponse vendorResponse = vendorResponses.SingleOrDefault(q => q.VendorName == vendorName);
         if (vendorResponse is null)
         {
            err.AppendLine($"line skip: vendor name not found ( line:{x},vendorname:{vendorName} )");
            continue;
         }

         ResponseItem responseItem = vendorResponse.ResponseItems.SingleOrDefault(q => q.Item.Code == item.Code);
         if (responseItem is null || output.Any(q => q.Id == responseItem.Id))
         {
            err.AppendLine($"line skip: item response in vendor response not found ( line:{x},itemcode:{item.Code} )");
            continue;
         }

         string electionReason = flds[2];
         responseItem.ElectionReason = electionReason;

         output.Add(responseItem);
      }

      error = err.ToString();
      return output;
   }
   public string ConvertElectionsToCSV(int bidId)
   {
      return _respondingRepo.GetResponseItems_ByBid(bidId)
          .Where(responseItem => responseItem.Elected)
          .OrderBy(responseItem => responseItem.Item.Code)
          .Select(printLine())
          .Prepend(_electionCSVHeader)
          .Append("")
          .JoinAsLines()
          .ToString();
   }

   private Func<ResponseItem, string> printLine()
   {
      return responseItem => $"{responseItem.Item.FormattedCode}," +
              $"{responseItem.VendorResponse.VendorName}," +
              $"{responseItem.ElectionReason}";
   }
}
