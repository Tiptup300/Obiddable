using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.Validations.Bidding.Requesting
{
   internal class RequestorsValidation
   {
      public void Validate_AddRequestor_ToBid(Dbc dbc, Requestor obj, int bidId)
      {
         validateRequestorValues(obj);

         var bid = dbc.Bids.AsNoTracking().Include(x => x.Requestors).Single(x => x.Id == bidId);

         if (bid.Requestors.Any(x => x.Name == obj.Name))
         {
            throw new DataValidationException("Requestor Name already exists for this bid.");
         }

         if (bid.Requestors.Any(q => q.Code == obj.Code))
         {
            throw new DataValidationException("Requestor Code already exists for this bid.");
         }
      }
      public void Validate_UpdateRequestor(Dbc dbc, Requestor obj)
      {
         validateRequestorValues(obj);

         if (obj.Bid is null)
         {
            throw new DataValidationException("Requestor Bid is null.");
         }

         var bid = dbc.Bids.AsNoTracking().Include(x => x.Requestors).Single(x => x.Id == obj.Bid.Id);
         if (bid.Requestors.Where(x => x.Id != obj.Id).Any(x => x.Name == obj.Name))
         {
            throw new DataValidationException("Requestor Name already exists for this bid.");
         }
         if (bid.Requestors.Where(x => x.Id != obj.Id).Any(q => q.Code == obj.Code))
         {
            throw new DataValidationException("Requestor Code already exists for this bid.");
         }
      }
      public void Validate_DeleteRequestor(Dbc dbc, int requestorId)
      {
         var requestor = dbc.Requestors.AsNoTracking().Include(x => x.Requests).Single(q => q.Id == requestorId);

         if (requestor.Requests.Count > 0)
         {
            throw new DataValidationException("Request exists for requestor");
         }

      }
      public void Validate_DeleteRequestors_ByBid(Dbc dbc, int bidId)
      {
         var requestors = dbc.Requestors.AsNoTracking().Include(x => x.Bid).Where(x => x.Bid.Id == bidId).ToList();
         requestors.ForEach(x => Validate_DeleteRequestor(dbc, x.Id));
      }
      private void validateRequestorValues(Requestor requestor)
      {
         requestor.Validate();
      }
   }
}
