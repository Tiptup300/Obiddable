using Obiddable.Library.Bidding;
using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Conversions.Bidding.Cataloging;
using Obiddable.Library.Validations;
using Obiddable.Win.UI;
using Obiddable.Win.UI.Bidding.Cataloging;

namespace Obiddable.Win.Library.IO.Bidding.Cataloging;
public class ItemsImportOperation
{
   private readonly CatalogingService _catalogingService;
   private readonly FormsMessaging _formsMessaging;
   private readonly CatalogingMessaging _catalogingMessaging;
   private readonly ItemsConversions _itemsConversions;

   public ItemsImportOperation(CatalogingService catalogingService, FormsMessaging formsMessaging, CatalogingMessaging catalogingMessaging, ItemsConversions itemsConversions)
   {
      _catalogingService = catalogingService;
      _formsMessaging = formsMessaging;
      _catalogingMessaging = catalogingMessaging;
      _itemsConversions = itemsConversions;
   }

   public void ImportItems(Bid bid)
   {
      string fileName = FileHelpers.OpenFile("Open Items Import", "csv");
      if (fileName is null)
      {
         return;
      }

      string errors = "";
      IEnumerable<Item> items = _itemsConversions.ConvertCSVToItems(File.ReadAllLines(fileName), out errors);

      if (errors != "")
      {
         _formsMessaging.ShowImportError(errors);
      }

      if (items is null || items.Count() == 0)
      {
         _formsMessaging.ShowImportNotCompleted();
         return;
      }

      addItemsToRepo(bid, items);
   }

   private void addItemsToRepo(Bid bid, IEnumerable<Item> items)
   {
      try
      {
         _catalogingService.AddItemsToBid(items, bid.Id);
      }
      catch (DataValidationException e)
      {
         _formsMessaging.ShowDataValidationExceptionError(e);
      }
      catch (Exception e)
      {
         _formsMessaging.ShowDatabaseOperationError(e.Message);
      }
   }
}
