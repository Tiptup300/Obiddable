using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Operations;
using Ccd.Bidding.Manager.Library.Validations;
using Ccd.Bidding.Manager.Win.UI;
using System;

namespace Ccd.Bidding.Manager.Win.Library.Operations
{
    public abstract class BidDataOperation : DataOperation
    {
        protected readonly Bid _bid;

        protected BidDataOperation(Bid bid)
        {
            _bid = bid;
        }

        public override void OnDataValidationException(DataValidationException ex)
        {
            FormsMessaging.Instance.ShowDataValidationExceptionError(ex);
        }
        public override void OnException(Exception ex)
        {
            FormsMessaging.Instance.ShowDatabaseOperationError(ex.Message);
        }
    }
}
