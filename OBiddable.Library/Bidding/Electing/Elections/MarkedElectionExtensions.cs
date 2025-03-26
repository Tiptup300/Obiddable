namespace OBiddable.Library.Bidding.Electing.Elections;

public static class MarkedElectionExtensions
{
    public static bool IsResponseItemAlternate(this MarkedElection markedElection) 
        => markedElection.ElectedResponseItem.IsAlternate;

    public static string GetResponseItemVendorName(this MarkedElection markedElection)
        => markedElection.ElectedResponseItem.VendorResponse.VendorName;

    public static decimal GetResponseItemPrice(this MarkedElection markedElection)
        => markedElection.ElectedResponseItem.Price;
}
