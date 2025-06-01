using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Electing;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Conversions.Bidding.Electing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Validations;
using Ccd.Bidding.Manager.Win.Library.Operations.Bidding.Electing;
using Ccd.Bidding.Manager.Win.UI;
using Ccd.Bidding.Manager.Win.UI.Bidding.Electing;

namespace Ccd.Bidding.Manager.Win.Library.IO.Bidding.Electing;
public class ElectionsImports
{
   private readonly ICatalogingRepo _catalogingRepo;
   private readonly IRespondingRepo _respondingRepo;
   private readonly ILegacyElectionsRepo _electionsRepo;
   private readonly ElectionsConversions _electionsConversions;
   public ElectionsImports()
       : this(
             new EFCatalogingRepo(),
             new EFRespondingRepo(),
             new EFLegacyElectionsRepo(),
             new ElectionsConversions(
                 new EFCatalogingRepo(),
                 new EFRespondingRepo()))
   {

   }

   public ElectionsImports(ICatalogingRepo catalogingRepo,
       IRespondingRepo respondingRepo,
       ILegacyElectionsRepo electionsRepo,
       ElectionsConversions electionsConversions)
   {
      _catalogingRepo = catalogingRepo;
      _respondingRepo = respondingRepo;
      _electionsRepo = electionsRepo;
      _electionsConversions = electionsConversions;
   }

   public void ImportElectionsFromCSV(Bid bid)
   {
      string fileName = FileHelpers.OpenFile("Open Elections Import", "csv");
      if (fileName is null)
      {
         return;
      }

      string errors = "";
      List<ResponseItem> elections = _electionsConversions.ConvertCSVToElections(File.ReadAllLines(fileName), bid.Id, out errors);
      //File.ReadAllLines(fileName).ConvertCSVToElections(bid.Id, out errors, _catalogingRepo, _respondingRepo);

      if (errors != "")
      {
         FormsMessaging.Instance.ShowImportError(errors);
      }

      if (elections is null || elections.Count == 0)
      {
         FormsMessaging.Instance.ShowImportNotCompleted();
         return;
      }

      try
      {
         foreach (ResponseItem ri in elections)
         {
            new ElectItemOperation().ElectResponseItem(ri.Item.Id, ri.Id, ri.ElectionReason);
         }

         ElectingMessaging.Instance.ShowElectionImportSuccess(elections);
      }
      catch (DataValidationException e)
      {
         FormsMessaging.Instance.ShowDataValidationExceptionError(e);
      }
      catch (Exception e)
      {
         FormsMessaging.Instance.ShowDatabaseOperationError(e.Message);
      }
   }
}
