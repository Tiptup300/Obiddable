using Ccd.Bidding.Manager.Library.Validations;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Electing
{
    public static class ElectingValidations
    {
        public static void Validate_UpdateResponseItem_Elect(this Dbc dbc, int itemId, int responseItemId, string reasonElected)
        {
            if (reasonElected is null)
            {
                throw new DataValidationException("reason elected cannot be null");
            }
        }
    }
}
