namespace Ccd.Bidding.Manager.Reporting.Html.Tables
{
   public class Header
   {
      public string Title { get; private set; }
      public string Class { get; private set; }


      public Header(string title, string @class)
      {
         Title = title;
         Class = @class;
      }

   }
}
