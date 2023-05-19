using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.EF;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting.RequestItems;
using Ccd.Bidding.Manager.Library.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.Validations.Bidding.Requesting
{
    internal class RequestsValidation
    {
        public void Validate_AddRequest_ToRequestor(Dbc dbc, Request obj, int requestorId)
        {
            validateRequestValues(obj);

            var requestor = dbc.Requestors.AsNoTracking().Include(x => x.Requests).Single(x => x.Id == requestorId);
            if (requestor.Requests.Any(x => x.Account_Number == obj.Account_Number))
            {
                throw new DataValidationException("Account Number already exists in this request.");
            }
        }

        public void Validate_UpdateRequest(Dbc dbc, Request obj)
        {
            validateRequestValues(obj);

            if (obj.Requestor is null)
            {
                throw new DataValidationException("Request Requestor is null.");
            }

            var requestor = dbc.Requestors.AsNoTracking().Include(x => x.Requests).Single(x => x.Id == obj.Requestor.Id);
            if (requestor.Requests.Where(x => x.Id != obj.Id).Any(x => x.Account_Number == obj.Account_Number))
            {
                throw new DataValidationException("Account Number already exists in this request.");
            }
        }
        public void Validate_DeleteRequest(Dbc dbc, int requestId)
        {
            var request = dbc.Requests.AsNoTracking().Include(x => x.RequestItems).Single(x => x.Id == requestId);

            if (request.RequestItems.Count > 0)
            {
                throw new DataValidationException("Request has request items.");
            }
        }
        public void Validate_DeleteRequests_ByRequestor(Dbc dbc, int requestorId)
        {
            var requests = dbc.Requests.AsNoTracking().Include(x => x.Requestor).Where(x => x.Requestor.Id == requestorId).ToList();
            requests.ForEach(x => Validate_DeleteRequest(dbc,x.Id));
        }

        public void Validate_ClearRequests_ByRequestor(Dbc dbc, int requestorId, RequestItemsValidation requestItemsValidations)
        {
            var requests = dbc.Requests.AsNoTracking().Include(x => x.Requestor).Where(x => x.Requestor.Id == requestorId).ToList();
            requests
                .ForEach(x => requestItemsValidations.Validate_DeleteRequestItems_ByRequest(dbc, x.Id));
        }

        public void Validate_DeleteRequests_ByBid(Dbc dbc, int bidId)
        {
            var requests = dbc.Requests.AsNoTracking().Include(x => x.Requestor).ThenInclude(x => x.Bid).Where(x => x.Requestor.Bid.Id == bidId).ToList();
            requests.ForEach(x => Validate_DeleteRequest(dbc, x.Id));
        }
        private void validateRequestValues(Request request)
        {
            request.Validate();
        }
    }
}
