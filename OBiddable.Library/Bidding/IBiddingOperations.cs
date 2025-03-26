namespace OBiddable.Library.Bidding;

public interface IBiddingOperations
{
    bool ClearAndDeleteBid(Bid bid);
    Bid DuplicateBid(int bidId);
    Bid RollBid(int bidId);
}
