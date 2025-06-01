using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Win.Library.UI;

namespace Ccd.Bidding.Manager.Win.UI.Bidding.Purchasing;
public class PurchasingMessaging : MessagingService
{
   public static PurchasingMessaging Instance = new PurchasingMessaging();
   #region PURCHASE ORDER
   public bool ConfirmPurchaseOrderGenerate()
   {
      string message = "Are you sure you would like to regenerate all purchase orders for this bid? All current purchase orders will be deleted?";
      string caption = "Regenerate Purchase Orders?";
      return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
   }

   public void ShowPurchaseOrderGenerateSuccess(IEnumerable<PurchaseOrder> purchaseOrders)
   {
      decimal total;
      int count;
      string message;
      string caption;

      count = purchaseOrders.Count();
      total = purchaseOrders.Sum(po => po.GetExtendedPriceSumOfLineItems());
      message = $"Purchase Orders Successfully Created.\nPurchase Orders Generated: {count}\nTotal Extended Price: {total}";
      caption = "Purchase Order Generation Successful";
      ShowSuccess(message, caption);
   }
   public void ShowPurchaseOrderMultipleElectionsError()
   {
      string message = "Multiple Elections Found For Reponse. Please clear all elections & rerun low bid process.";
      string caption = "Database Integrity Error";
      ShowError(message, caption);
   }
   public void ShowPurchaseOrderFailedToLoadError()
   {
      string message = "The purchase order failed to load.";
      string caption = "Load Failed";
      ShowError(message, caption);
   }
   public void ShowPurchaseOrderExportSuccess()
   {
      string message = "The Puchase Order export completed successfully.";
      string caption = "Export Successful";
      ShowSuccess(message, caption);
   }

   public bool ConfirmPurchaseOrderDelete()
   {
      string message = "Are you sure you would like to delete this purchase order? This cannot be undone.";
      string caption = "Delete Purchase Order?";
      return ShowYesNoConfirmation(message, caption) == DialogResult.Yes;
   }
   #endregion
}
