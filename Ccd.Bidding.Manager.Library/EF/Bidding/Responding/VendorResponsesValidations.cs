using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF;
using Ccd.Bidding.Manager.Library.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Responding
{
    public static class VendorResponsesValidations
    {
        public static void Validate_AddVendorResponse_ToBid(this Dbc dbc, VendorResponse obj, int bidId)
        {
            validateVendorResponseValues(obj);

            var bid = dbc.Bids.AsNoTracking().Include(x => x.VendorResponses).Single(x => x.Id == bidId);

            if (bid.VendorResponses.Any(q => q.VendorName == obj.VendorName))
            {
                throw new DataValidationException("Vendor Name already exists within this bid.");

            }
        }
        public static void Validate_UpdateVendorResponse(this Dbc dbc, VendorResponse obj)
        {
            validateVendorResponseValues(obj);

            if (obj.Bid is null)
            {
                throw new DataValidationException("VendorResponse Bid is null");
            }

            var bid = dbc.Bids.AsNoTracking().Include(x => x.VendorResponses).Single(x => x.Id == obj.Bid.Id);

            if (bid.VendorResponses.Where(x => x.Id != obj.Id).Any(q => q.VendorName == obj.VendorName))
            {
                throw new DataValidationException("Vendor Name already exists within this bid.");

            }
        }
        public static void Validate_DeleteVendorResponse(this Dbc dbc, int vendorResponseId)
        {
            var vendorResponse = dbc.VendorResponses.AsNoTracking().Include(x => x.ResponseItems).Single(x => x.Id == vendorResponseId);

            if (vendorResponse.ResponseItems.Count > 0)
            {
                throw new DataValidationException("VendorResponse ResponseItems.Count > 0 ");
            }
        }
        public static void Validate_DeleteVendorResponses_ByBid(this Dbc dbc, int bidId)
        {
            // validate each VendorResponse to be deleted
            var vendorResponses = dbc.VendorResponses.AsNoTracking().Include(x => x.Bid).Where(x => x.Bid.Id == bidId).ToList();
            vendorResponses.ForEach(x => dbc.Validate_DeleteVendorResponse(x.Id));
        }
        private static void validateVendorResponseValues(VendorResponse vendorResponse)
        {
            vendorResponse.Validate();
        }
    }
}
