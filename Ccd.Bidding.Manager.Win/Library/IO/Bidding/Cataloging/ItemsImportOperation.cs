using System;
using System.Collections.Generic;
using System.IO;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Win.Library.IO;
using Ccd.Bidding.Manager.Library.Conversions.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Validations;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Win.UI;
using Ccd.Bidding.Manager.Win.UI.Bidding.Cataloging;
using System.Linq;
using Ccd.Bidding.Manager.Library.Operations;

namespace Ccd.Bidding.Manager.Win.Library.IO.Bidding.Cataloging
{
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
                _catalogingMessaging.ShowItemImportSuccess(items.Count());
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
}
