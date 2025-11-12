using Obiddable.Library.Bidding;

namespace Obiddable.Win.Library.IO;
public class ExportFileNameFactory
{
   public string BuildFileName(Bid bid, string type, string extension, string detail, DateTime dateTime)
   {
      string output;
      string timestamp;

      detail = addDoubleHypensIfSet(detail);
      timestamp = getTimestamp(dateTime);
      output = buildFileName(bid, type, extension, detail, timestamp);

      return output;
   }


   private string addDoubleHypensIfSet(string str)
   {
      string output;

      output = "";
      if (str != "")
      {
         output = $"--{str}";
      }

      return output;
   }


   private string getTimestamp(DateTime dateTime)
   {
      string output;

      output = buildTimestamp(dateTime);
      if (isTimestampingFilesDisabled())
      {
         output = "-";
      }

      return output;
   }
   private string buildTimestamp(DateTime dateTime)
       => $"--{dateTime.ToString("yyyy-MM-dd-HH-mm")}--";
   private static bool isTimestampingFilesDisabled()
   {
      return UserConfiguration.Instance.IncludeTimestampsOnAllFiles == false;
   }


   private static string buildFileName(Bid bid, string type, string extension, string detail, string timestamp)
       => $"Bid{bid.Id}{timestamp}{type}{detail}.{extension}".MakeValidFileName();
}
