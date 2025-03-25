using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Electing
{
    public class EFLegacyElectionsRepo : ILegacyElectionsRepo
    {

        private static readonly ElectionsConversionService _conversionService = new ElectionsConversionService();

        public IEnumerable<ResponseItem> GetElectedResponseItemsByBid(int bidId)
        {
            using (var dbc = new Dbc())
            {
                return dbc.ResponseItems
                    .Include(x => x.Item)
                    .Include(x => x.VendorResponse)
                    .ThenInclude(x => x.Bid)
                    .Where(responseItem => responseItem.VendorResponse.Bid.Id == bidId)
                    .Where(requestItem => requestItem.Elected)
                    .ToList();
            }
        }

        public ResponseItem GetElectedResponseItemForItem(int itemId)
        {
            using (var dbc = new Dbc())
            {
                return dbc.ResponseItems
                    .AsNoTracking()
                    .Include(x => x.Item)
                    .Include(x => x.VendorResponse)
                    .ThenInclude(x => x.Bid)
                    .Where(ri => ri.Item.Id == itemId)
                    .FirstOrDefault(x => x.Elected);
            }
        }
        public List<ResponseItem> GetResponseItems_Elected_ByVendorResponse(int vendorResponseId)
        {
            using (var dbc = new Dbc())
            {
                return dbc.ResponseItems
                    .AsNoTracking()
                    .Include(x => x.VendorResponse)
                    .Include(x => x.VendorResponse.Bid)
                    .Include(x => x.Item)
                    .Where(ri => ri.VendorResponse.Id == vendorResponseId)
                    .Where(x => x.Elected)
                    .ToList();
            }
        }


        public void UpdateResponseItem_Elect(int itemId, int responseItemId, string reasonElected)
        {
            using (var dbc = new Dbc())
            {
                dbc.Validate_UpdateResponseItem_Elect(itemId, responseItemId, reasonElected);

                // clear all elected responses for this item.
                List<ResponseItem> electedResponsesForThisItem = dbc.ResponseItems
                    .Include(x => x.Item)
                    .Include(x => x.VendorResponse)
                    .ThenInclude(x => x.Bid)
                    .Where(y => y.Item.Id == itemId)
                    .ToList();

                electedResponsesForThisItem.ForEach(x => x.Elected = false);
                electedResponsesForThisItem.ForEach(x => x.ElectionReason = null);

                var ri = dbc.ResponseItems.FirstOrDefault(x => x.Id == responseItemId);

                ri.Elected = true;
                ri.ElectionReason = reasonElected;

                dbc.SaveChanges();
            }
            _conversionService.ElectResponseItem(itemId, responseItemId, reasonElected);
        }
        public void UpdateResponseItems_ClearElections_ByBid(int bidId)
        {
            List<ResponseItem> electedResponseItemsForBid;

            using (var dbc = new Dbc())
            {
                dbc.Validate_UpdateResponseItems_ClearElections_ByBid(bidId);
                electedResponseItemsForBid = getElectedResponseItemsForBid(bidId, dbc);
                unelectResponseItems(electedResponseItemsForBid);
                dbc.SaveChanges();
            }
        }

        private static List<ResponseItem> getElectedResponseItemsForBid(int bidId, Dbc dbc)
        {
            return dbc.ResponseItems
                .Include(x => x.VendorResponse)
                .ThenInclude(x => x.Bid)
                .Where(x => x.VendorResponse.Bid.Id == bidId)
                .ToList();
        }

        public void UpdateResponseItems_ClearElections_ByItem(int itemId)
        {
            List<ResponseItem> electedResponseItemsForItem;

            using (var dbc = new Dbc())
            {
                dbc.Validate_UpdateResponseItems_ClearElections_ByItem(itemId);
                electedResponseItemsForItem = getElectedResponseItemsForItem(itemId, dbc);
                unelectResponseItems(electedResponseItemsForItem);
                dbc.SaveChanges();
            }
        }

        private static List<ResponseItem> getElectedResponseItemsForItem(int itemId, Dbc dbc)
        {
            return dbc.ResponseItems
                .Include(x => x.Item)
                .Include(x => x.VendorResponse)
                .ThenInclude(x => x.Bid)
                .Where(y => y.Item.Id == itemId)
                .ToList();
        }

        private void unelectResponseItems(List<ResponseItem> responseItems)
            => responseItems.ForEach(responseItem => unelectResponseItem(responseItem));


        private void unelectResponseItem(ResponseItem responseItem)
        {
            responseItem.Elected = false;
            responseItem.ElectionReason = null;

            _conversionService.UnelectResponseItem(responseItem.Id);
        }

        #region Cataloging
        public List<Item> GetItems_Responded_Elected_ByBid(int bidId)
        {
            using (var dbc = new Dbc())
            {
                List<Item> allBidItems = dbc.Items.Include(a => a.Bid).Where(b => b.Bid.Id == bidId).ToList();

                List<ResponseItem> electedResponseItems = dbc.ResponseItems
                    .Include(x => x.Item)
                    .Include(x => x.VendorResponse)
                    .ThenInclude(x => x.Bid)
                    .Where(x => x.VendorResponse.Bid.Id == bidId)
                    .Where(x => x.Elected)
                    .ToList();

                return allBidItems.Where(x => electedResponseItems.Any(y => y.Item.Id == x.Id)).ToList();
            }
        }
        public List<Item> GetItems_Responded_NotElected_ByBid(int bidId)
        {
            using (var dbc = new Dbc())
            {
                List<Item> allBidItems = dbc.Items.Include(a => a.Bid).Where(b => b.Bid.Id == bidId).ToList();

                List<ResponseItem> allResponseItems = dbc.ResponseItems
                    .Include(x => x.Item)
                    .Include(x => x.VendorResponse)
                    .ThenInclude(x => x.Bid)
                    .Where(x => x.VendorResponse.Bid.Id == bidId)
                    .ToList();

                List<ResponseItem> electedResponseItems = dbc.ResponseItems
                    .Include(x => x.Item)
                    .Include(x => x.VendorResponse)
                    .ThenInclude(x => x.Bid)
                    .Where(x => x.VendorResponse.Bid.Id == bidId)
                    .Where(x => x.Elected)
                    .ToList();

                return allBidItems.Where(x => allResponseItems.Any(y => y.Item.Id == x.Id) && !electedResponseItems.Any(y => y.Item.Id == x.Id)).ToList();
            }
        }

        #endregion
    }

}
