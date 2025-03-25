using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Distribution;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Win.UI.Bidding.Electing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Win.Library.Operations.Bidding.Electing
{
    public class ElectItemOperation
    {
        private readonly ElectingMessaging _electingMessaging = new ElectingMessaging();
        private readonly ILegacyElectionsRepo _legacyElectionsRepo;
        private readonly ICatalogingRepo _catalogingRepo;
        private readonly IRequestingRepo _requestingRepo;
        private readonly IRespondingRepo _respondingRepo;

        public ElectItemOperation() 
            : this(new EFLegacyElectionsRepo(), new EFCatalogingRepo(), new EFRequestingRepo(), new EFRespondingRepo())
        {

        }

        public ElectItemOperation(ILegacyElectionsRepo legacyElectionsRepo, ICatalogingRepo catalogingRepo, IRequestingRepo requestingRepo, IRespondingRepo respondingRepo)
        {
            _legacyElectionsRepo = legacyElectionsRepo;
            _catalogingRepo = catalogingRepo;
            _requestingRepo = requestingRepo;
            _respondingRepo = respondingRepo;
        }

        public void ElectResponseItem(int itemId, int responseItemId, string reason)
        {
            Item item;
            ResponseItem responseItem;

            item = _catalogingRepo.GetItem(itemId);
            responseItem = _respondingRepo.GetResponseItem(responseItemId);
            if (shouldStopBecauseOfMismatchedQuantity(item, responseItem))
            {
                return;
            }
            _legacyElectionsRepo.UpdateResponseItem_Elect(itemId, responseItemId, reason);
        }
        private bool shouldStopBecauseOfMismatchedQuantity(Item item, ResponseItem responseItem)
        {
            if (responseItem.IsMismatchedQuantity(_requestingRepo) == false)
            {
                return false;
            }
            return (_electingMessaging.ConfirmContinueIfMismatched(responseItem, _requestingRepo.GetItemsRequestedQuantity(item), responseItem.AlternateQuantity) == false);
        }
    }
}
