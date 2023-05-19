using Ccd.Bidding.Manager.Library.Bidding.Distribution;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.Bidding.Purchasing
{
    public class PurchasingService
    {
        private readonly IRespondingRepo _respondingRepo;
        private readonly IRequestingRepo _requestingRepo;
        private readonly ILegacyElectionsRepo _electionsRepo;
        private readonly DistributionService _distributionService;
        private readonly IPurchasingRepo _purchasingRepo;

        public PurchasingService(IRespondingRepo respondingRepo, IRequestingRepo requestingRepo,
            ILegacyElectionsRepo electionsRepo, DistributionService distributionService, IPurchasingRepo purchasingRepo)
        {
            _respondingRepo = respondingRepo;
            _requestingRepo = requestingRepo;
            _electionsRepo = electionsRepo;
            _distributionService = distributionService;
            _purchasingRepo = purchasingRepo;
        }


        public void AddPurchaseOrdersToBid(int bidId, IEnumerable<PurchaseOrder> purchaseOrders)
        {
            foreach (PurchaseOrder purchaseOrder in purchaseOrders)
            {
                _purchasingRepo.AddPurchaseOrder_ToBid(purchaseOrder, bidId);
            }
        }

        public bool DoPurchaseOrdersExistOnBid(int bidId)
        {
            return _purchasingRepo.GetPurchaseOrders_ByBid(bidId)
                .Count() > 0;
        }

        public void ClearAllPurchaseOrdersOnBid(int bidId)
        {
            _purchasingRepo.DeleteLineItems_ByBid(bidId);
            _purchasingRepo.DeletePurchaseOrders_ByBid(bidId);
        }

        public IEnumerable<PurchaseOrder> GeneratePurchaseOrders(Bid bid)
        {
            IEnumerable<PurchaseOrder> output;
            string[] buildingNames;

            buildingNames = _requestingRepo.GetRequestorsBuildingNames_ByBid(bid.Id);
            output = _respondingRepo.GetVendorResponses_ByBid(bid.Id)
                .SelectMany(
                    vendorResponse => generatePurchaseOrdersForVendorResponse(vendorResponse, buildingNames));

            return output;
        }

        private IEnumerable<PurchaseOrder> generatePurchaseOrdersForVendorResponse(VendorResponse vendorResponse, string[] buildingNames)
        {
            List<ResponseItem> electedResponseItems;

            electedResponseItems = _electionsRepo.GetResponseItems_Elected_ByVendorResponse(vendorResponse.Id);
            return buildingNames
                .Select(buildingName => generatePurchaseOrder(vendorResponse.Bid, buildingName, vendorResponse.VendorName, electedResponseItems))
                .Where(po => po.LineItems.Count > 0);
        }

        private PurchaseOrder generatePurchaseOrder(Bid bid, string buildingName, string vendorName, IEnumerable<ResponseItem> electedResponseItems)
        {
            PurchaseOrder output;

            output = new PurchaseOrder(null,
                generateLineItemsForPuchaseOrder(bid, buildingName, electedResponseItems),
                vendorName,
                buildingName,
                DateTime.Now);

            return output;
        }

        private IEnumerable<LineItem> generateLineItemsForPuchaseOrder(Bid bid, string buildingName, IEnumerable<ResponseItem> electedResponseItems)
        {
            return _requestingRepo.GetRequestors_ByBuildingName(bid.Id, buildingName)
                .SelectMany(requestor => _requestingRepo.GetRequests_ByRequestor(requestor.Id))
                .SelectMany(request => getElectedRequestItemsForRequest(electedResponseItems, request))
                .Select(requestItem
                    => generateLineItem(
                        electedResponseItems.SingleOrDefault(x => x.Item.Id == requestItem.Item.Id),
                        requestItem.Request,
                        requestItem));
        }

        private IEnumerable<RequestItem> getElectedRequestItemsForRequest(IEnumerable<ResponseItem> electedResponseItems, Request request)
        {
            return _requestingRepo.GetRequestItems_ByRequest(request.Id)
                .Where(requestItem => electedResponseItems
                    .SingleOrDefault(x => x.Item.Id == requestItem.Item.Id) is null == false);
        }

        private LineItem generateLineItem(ResponseItem electedResponseItem, Request request, RequestItem requestItem)
        {
            LineItem output;
            string accountNumber;
            string description;
            string partNumber;
            decimal price;
            decimal quantity;
            string unit;
            string note;
            int itemCode;
            int itemId;

            accountNumber = request.Account_Number;
            description = $"{ electedResponseItem.Item.FormattedCode } -- { electedResponseItem.Item.Description } { (electedResponseItem.IsAlternate ? $"(Vendor Note: { electedResponseItem.AlternateDescription })" : "") }";
            partNumber = electedResponseItem.Code;
            price = electedResponseItem.Price;
            if (electedResponseItem.IsMismatchedQuantity(_requestingRepo))
            {
                try
                {
                    quantity = _distributionService.GetDistributedQuantity(request.Requestor, electedResponseItem.Item).Quantity;
                }
                catch (UnmatchedQuantityWithoutDistributionException)
                {
                    quantity = -1;
                }
            }
            else
            {
                quantity = requestItem.Quantity;
            }
            unit = electedResponseItem.IsAlternate ? electedResponseItem.AlternateUnit : electedResponseItem.Item.Unit;
            note = electedResponseItem.IsAlternate ? "alternate" : "";
            itemCode = electedResponseItem.Item.Code;
            itemId = electedResponseItem.Item.Id;
            output = new LineItem(null, accountNumber, description, partNumber, price, quantity, unit, note, itemCode, itemId);

            return output;
        }
    }
}
