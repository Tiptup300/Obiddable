using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting.RequestItems;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting.Requestors;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting.Requests;
using Ccd.Bidding.Manager.Library.Validations.Bidding.Requesting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Requesting.Requests
{
    internal class RequestsRepo
    {
        private readonly RequestsValidation _requestsValidation = new RequestsValidation();
        private readonly RequestItemsValidation _requestItemsValidation = new RequestItemsValidation();
        private readonly RequestItemsRepo _requestItemsRepo = new RequestItemsRepo();

        public void AddRequest_ToRequestor(Request obj, int requestorId)
        {
            using (var dbc = new Dbc())
            {
                _requestsValidation.Validate_AddRequest_ToRequestor(dbc, obj, requestorId);

                Requestor requestor = dbc.Requestors
                    .Where(x => x.Id == requestorId)
                    .Include(x => x.Requests)
                    .Single();

                requestor.Requests.Add(obj);
                dbc.SaveChanges();
            }
        }
        public void UpdateRequest(Request obj)
        {
            using (var dbc = new Dbc())
            {
                _requestsValidation.Validate_UpdateRequest(dbc, obj);

                var r = dbc.Requests.SingleOrDefault(x => x.Id == obj.Id);

                if (r is null)
                    return;

                r.Account_Number = obj.Account_Number;

                dbc.SaveChanges();

            }
        }
        public void DeleteRequest(int requestId)
        {
            using (var dbc = new Dbc())
            {
                _requestsValidation.Validate_DeleteRequest(dbc, requestId);

                var r = dbc.Requests.Include(x => x.RequestItems).SingleOrDefault(x => x.Id == requestId);

                if (r is null)
                    return;

                dbc.RequestItems.RemoveRange(dbc.RequestItems.Include(x => x.Request).Where(x => x.Request.Id == requestId).ToList());

                dbc.Remove(r);
                dbc.SaveChanges();
            }
        }
        public void ClearRequests_ByRequestor(int requestorId)
        {
            using (var dbc = new Dbc())
            {
                _requestsValidation.Validate_ClearRequests_ByRequestor(dbc, requestorId, _requestItemsValidation);
                Requestor requestor = dbc.Requestors
                    .Where(x => x.Id == requestorId)
                    .Include(a => a.Requests).ThenInclude(x => x.RequestItems)
                    .Single();

                requestor.Requests.ForEach(x => x.RequestItems.ForEach(y => _requestItemsRepo.DeleteRequestItem(y.Id)));
                dbc.SaveChanges();
            }
        }
        public void DeleteRequests_ByBid(int bidId)
        {
            using (var dbc = new Dbc())
            {
                _requestsValidation.Validate_DeleteRequests_ByBid(dbc, bidId);

                var requests = dbc.Requests.Include(x => x.Requestor).ThenInclude(x => x.Bid).Where(x => x.Requestor.Bid.Id == bidId).ToList();
                requests.ForEach(x => dbc.Remove(x));
                dbc.SaveChanges();
            }
        }
        // gets
        public Request GetRequest(int requestId)
        {
            using (var dbc = new Dbc())
            {
                return dbc.Requests
                    .Where(x => x.Id == requestId)
                    .Include(x => x.Requestor)
                    .ThenInclude(x => x.Bid)
                    .Include(x => x.RequestItems)
                    .ThenInclude(x => x.Item)
                    .Single();
            }
        }
        public List<Request> GetRequests_ByRequestor(int requestorId)
        {
            using (var dbc = new Dbc())
            {
                return dbc.Requests
                .Include(a => a.Requestor)
                .Include(a => a.Requestor.Bid)
                .Include(x => x.RequestItems)
                .ThenInclude(x => x.Item)
                .Where(r => r.Requestor.Id == requestorId)
                .ToList();
            }
        }
        public string[] GetRequestAccoutNumbers_ByBid(int bidId)
        {
            using (var dbc = new Dbc())
            {
                return dbc.Requests
                .Include(b => b.Requestor).ThenInclude(x => x.Bid)
                .Where(x => x.Requestor.Bid.Id == bidId)
                .Where(x => x.Account_Number != "")
                .Select(x => x.Account_Number)
                .Distinct().ToArray();
            }
        }
        // checks
        public bool Check_RequestAccountNumberAlreadyExists_InRequestor(string accountNumber, int requestorId, int requestId)
        {
            using (var dbc = new Dbc())
            {
                return dbc.Requests
                    .Include(x => x.Requestor)
                    .Where(x => x.Id != requestId)
                    .Where(x => x.Requestor.Id == requestorId)
                    .Any(x => x.Account_Number == accountNumber);
            }
        }

    }
}
