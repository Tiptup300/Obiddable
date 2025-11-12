using Obiddable.Library.Bidding.Cataloging;
using Obiddable.Library.Bidding.Electing;
using Obiddable.Library.Bidding.Electing.Elections;
using Obiddable.Library.Bidding.Responding;

namespace Obiddable.Test.Bidding.Electing;
public class ElectionTests
{
   [Fact]
   public void DoElectionsWork()
   {
      Item widget = new Item(null, null, 15, "", "Description", false, "Each", 0, 0);
      ResponseItem widgetResponse = new ResponseItem(15, widget, null, 10, 0, null, false, null, false, null);


      Election election = new UnmarkedElection(widget);
      election = election.Elect(widgetResponse, "reason");
      Assert.True(election.Item.Code == 15);
      Assert.True(election.IsNew());
      Assert.True(election is MarkedElection);



      MarkedElection markedElection = election as MarkedElection;
      Assert.True(markedElection.ElectedResponseItem.Id == 15);
      Assert.True(markedElection.GetResponseItemPrice() == 10);
      Assert.True(markedElection.Reason == "reason");


      ResponseItem betterWidgetResponse = new ResponseItem(28, widget, null, 8, 0, null, false, null, false, null);
      election = election.Elect(betterWidgetResponse, "better reason");
      MarkedElection markedElection2 = election as MarkedElection;
      Assert.True(markedElection2.ElectedResponseItem.Id == 28);
      Assert.True(markedElection2.GetResponseItemPrice() == 8);
      Assert.True(markedElection2.Reason == "better reason");
   }
}
