using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting.RequestItems;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting.Requestors;
using Ccd.Bidding.Manager.Library.EF.Bidding.Requesting.Requests;
using Ccd.Bidding.Manager.Library.Validations.Bidding.Requesting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Requesting.Requestors
{
    internal class RequestorsRepo
    {
        private readonly RequestorsValidation _requestorsValidation = new RequestorsValidation();

        public void AddRequestor_ToBid(Requestor obj, int bidId)
        {
            using (var dbc = new Dbc())
            {
                _requestorsValidation.Validate_AddRequestor_ToBid(dbc, obj, bidId);

                Bid bid = dbc.Bids
                    .Where(x => x.Id == bidId)
                    .Include(a => a.Requestors)
                    .Single();

                obj.Requests = null;

                bid.Requestors.Add(obj);
                dbc.SaveChanges();
            }
        }
        public void UpdateRequestor(Requestor obj)
        {
            using (var dbc = new Dbc())
            {

                _requestorsValidation.Validate_UpdateRequestor(dbc, obj);

                var r = dbc.Requestors.SingleOrDefault(x => x.Id == obj.Id);

                if (r is null)
                    return;

                r.Name = obj.Name;
                r.Code = obj.Code;
                r.Building = obj.Building;
                r.Password = obj.Password;
                r.AmountBudgeted = obj.AmountBudgeted;

                dbc.SaveChanges();

            }
        }
        public void DeleteRequestor(int requestorId)
        {
            using (var dbc = new Dbc())
            {
                _requestorsValidation.Validate_DeleteRequestor(dbc, requestorId);

                var r = dbc.Requestors.SingleOrDefault(x => x.Id == requestorId);

                if (r is null)
                    return;
                dbc.Remove(r);
                dbc.SaveChanges();
            }
        }
        public void DeleteRequestors_ByBid(int bidId)
        {
            using (var dbc = new Dbc())
            {
                _requestorsValidation.Validate_DeleteRequestors_ByBid(dbc, bidId);

                Bid bid = dbc.Bids
                    .Where(x => x.Id == bidId)
                    .Include(a => a.Requestors)
                    .Single();

                bid.Requestors.ForEach(x => dbc.Remove(x));

                dbc.SaveChanges();
            }
        }
        // gets
        public Requestor GetRequestor(int requestorId)
        {
            using (var dbc = new Dbc())
            {
                return dbc.Requestors
                    .Include(x => x.Bid)
                    .Include(x => x.Requests)
                    .ThenInclude(x => x.RequestItems)
                    .ThenInclude(x => x.Item)
                    .Where(x => x.Id == requestorId)
                    .Single();
            }
        }
        public List<Requestor> GetRequestors_ByBid(int bidId)
        {
            using (var dbc = new Dbc())
            {
                return dbc.Requestors
                .Include(a => a.Requests)
                .ThenInclude(x => x.RequestItems)
                .ThenInclude(x => x.Item)
                .Include(b => b.Bid)
                .Where(x => x.Bid.Id == bidId)
                .ToList();
            }
        }
        public List<Requestor> GetRequestors_ByBuildingName(int bidId, string buildingName)
        {
            using (var dbc = new Dbc())
            {
                return dbc.Requestors
                .Include(a => a.Requests)
                .ThenInclude(x => x.RequestItems)
                .ThenInclude(x => x.Item)
                .Include(b => b.Bid)
                .Where(x => x.Bid.Id == bidId)
                .Where(x => x.Building == buildingName)
                .ToList();
            }
        }
        public string[] GetRequestorsBuildingNames_ByBid(int bidId)
        {
            using (var dbc = new Dbc())
            {
                return dbc.Requestors
                .Include(b => b.Bid)
                .Where(x => x.Bid.Id == bidId)
                .Where(x => x.Building != "")
                .Select(x => x.Building)
                .Distinct().ToArray();
            }
        }
    }
}
