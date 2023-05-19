using System;
using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.Conversions.Bidding.Electing;
using Ccd.Bidding.Manager.Library.EF.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.EF.Bidding.Responding;
using Ccd.Bidding.Manager.Win.Library.IO;
using Ccd.Bidding.Manager.Win.UI.Bidding.Electing;

namespace Ccd.Bidding.Manager.Win.Library.IO.Bidding.Electing
{
    public static class ElectionsExports
    {
        private static readonly ExportFileNameFactory _fileNameGetter;
        private static readonly ElectionsConversions _electionsConversions;

        static ElectionsExports()
        {
            _fileNameGetter = new ExportFileNameFactory();
            _electionsConversions = new ElectionsConversions(new EFCatalogingRepo(), new EFRespondingRepo());
        }

        public static void ExportElectionsToCSV(Bid bid)
        {
            string fileName = _fileNameGetter.BuildFileName(bid, "elections", "csv", "", DateTime.Now);
            string data = _electionsConversions.ConvertElectionsToCSV(bid.Id);
            string title = "Save Elections Export";
            FileHelpers.SaveCSV(fileName, data, title, UserConfiguration.Instance.SupressFileLocationSelectDialog);

            ElectingMessaging.Instance.ShowElectionExportSuccess();
        }
    }
}
