namespace Ccd.Bidding.Manager.Win.Library.UI.ListViews;
public class SortableListView : ListView
{
   private ListViewColumnSorter _columnSorter = new ListViewColumnSorter();
   public SortableListView()
   {
      ListViewItemSorter = _columnSorter;
      setColumnClickEvent();
   }

   private void setColumnClickEvent()
       => ColumnClick += onColumnClick;

   private void onColumnClick(object sender, ColumnClickEventArgs e)
   {
      SortByColumn(e.Column);
   }
   public void SortByColumn(int columnIndex)
   {
      SortOrder sortOrder = SortOrder.Ascending;

      // Determine if clicked column is already the column that is being sorted.
      if (columnIndex == _columnSorter.SortColumn)
      {
         // Reverse the current sort direction for this column.
         if (_columnSorter.Order == SortOrder.Ascending)
         {
            sortOrder = SortOrder.Descending;
         }
         else
         {
            sortOrder = SortOrder.Ascending;
         }
      }

      SortByColumn(columnIndex, sortOrder);
   }
   public void SortByColumn(int columnIndex, SortOrder sortOrder)
   {
      _columnSorter.SortColumn = columnIndex;
      _columnSorter.Order = sortOrder;


      Sort();
      this.SetSortIcon(_columnSorter.SortColumn, _columnSorter.Order);
   }

   // Allows selected item to stay blue when made blue.
   protected override void DefWndProc(ref Message msg)
   {
      if (msg.Msg != 8)
         base.DefWndProc(ref msg);
   }

   public void ReplaceListViewItems(IEnumerable<ListViewItem> listViewItems)
   {
      BeginUpdate();
      Items.Clear();
      Items.AddRange(listViewItems.ToArray());
      EndUpdate();
   }
}
