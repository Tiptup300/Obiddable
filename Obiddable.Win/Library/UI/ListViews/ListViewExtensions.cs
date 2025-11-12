using System.Runtime.InteropServices;

namespace Obiddable.Win.Library.UI.ListViews;
internal static class ListViewExtensions
{
   [StructLayout(LayoutKind.Sequential)]
   public struct LVCOLUMN
   {
      public int mask;
      public int cx;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszText;
      public IntPtr hbm;
      public int cchTextMax;
      public int fmt;
      public int iSubItem;
      public int iImage;
      public int iOrder;
   }

   const int HDI_WIDTH = 0x0001;
   const int HDI_HEIGHT = HDI_WIDTH;
   const int HDI_TEXT = 0x0002;
   const int HDI_FORMAT = 0x0004;
   const int HDI_LPARAM = 0x0008;
   const int HDI_BITMAP = 0x0010;
   const int HDI_IMAGE = 0x0020;
   const int HDI_DI_SETITEM = 0x0040;
   const int HDI_ORDER = 0x0080;
   const int HDI_FILTER = 0x0100;

   const int HDF_LEFT = 0x0000;
   const int HDF_RIGHT = 0x0001;
   const int HDF_CENTER = 0x0002;
   const int HDF_JUSTIFYMASK = 0x0003;
   const int HDF_RTLREADING = 0x0004;
   const int HDF_OWNERDRAW = 0x8000;
   const int HDF_STRING = 0x4000;
   const int HDF_BITMAP = 0x2000;
   const int HDF_BITMAP_ON_RIGHT = 0x1000;
   const int HDF_IMAGE = 0x0800;
   const int HDF_SORTUP = 0x0400;
   const int HDF_SORTDOWN = 0x0200;

   const int LVM_FIRST = 0x1000;         // List messages
   const int LVM_GETHEADER = LVM_FIRST + 31;
   const int HDM_FIRST = 0x1200;         // Header messages
   const int HDM_SETIMAGELIST = HDM_FIRST + 8;
   const int HDM_GETIMAGELIST = HDM_FIRST + 9;
   const int HDM_GETITEM = HDM_FIRST + 11;
   const int HDM_SETITEM = HDM_FIRST + 12;

   [DllImport("user32.dll")]
   private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

   [DllImport("user32.dll", EntryPoint = "SendMessage")]
   private static extern IntPtr SendMessageLVCOLUMN(IntPtr hWnd, int Msg, IntPtr wParam, ref LVCOLUMN lPLVCOLUMN);


   //This method used to set arrow icon
   public static void SetSortIcon(this ListView listView, int columnIndex, SortOrder order)
   {
      IntPtr columnHeader = SendMessage(listView.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);

      for (int columnNumber = 0; columnNumber <= listView.Columns.Count - 1; columnNumber++)
      {
         IntPtr columnPtr = new IntPtr(columnNumber);
         LVCOLUMN lvColumn = new LVCOLUMN();
         lvColumn.mask = HDI_FORMAT;

         SendMessageLVCOLUMN(columnHeader, HDM_GETITEM, columnPtr, ref lvColumn);

         if (!(order == SortOrder.None) && columnNumber == columnIndex)
         {
            switch (order)
            {
               case SortOrder.Ascending:
                  lvColumn.fmt &= ~HDF_SORTDOWN;
                  lvColumn.fmt |= HDF_SORTUP;
                  break;
               case SortOrder.Descending:
                  lvColumn.fmt &= ~HDF_SORTUP;
                  lvColumn.fmt |= HDF_SORTDOWN;
                  break;
            }
            lvColumn.fmt |= HDF_LEFT | HDF_BITMAP_ON_RIGHT;
         }
         else
         {
            lvColumn.fmt &= ~HDF_SORTDOWN & ~HDF_SORTUP & ~HDF_BITMAP_ON_RIGHT;
         }

         SendMessageLVCOLUMN(columnHeader, HDM_SETITEM, columnPtr, ref lvColumn);
      }
   }
}
