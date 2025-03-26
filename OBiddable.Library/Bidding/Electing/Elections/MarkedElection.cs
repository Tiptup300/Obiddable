using OBiddable.Library.Bidding.Responding;

namespace OBiddable.Library.Bidding.Electing.Elections;

public class MarkedElection : Election
{
    public ResponseItem ElectedResponseItem { get; private set; }
    public string Reason { get; private set; }

    public MarkedElection(ResponseItem electedResponseItem, string reason, int? id = null) : base(electedResponseItem.Item, id)
    {
        ElectedResponseItem = electedResponseItem ?? throw new ArgumentNullException(nameof(electedResponseItem));
        Reason = reason ?? throw new ArgumentNullException(nameof(reason));
    }

    public override MarkedElection Elect(ResponseItem newElectedResponseItem, string reason)
        => new MarkedElection(newElectedResponseItem, reason, Id);

    public UnmarkedElection Unelect()
        => new UnmarkedElection(Item, Id);

    public override string ToString()
        => $"Marked Election:({Item}<->{ElectedResponseItem})";
}
