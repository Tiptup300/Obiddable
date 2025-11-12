using System.Text;

namespace Obiddable.Win.Library.UI;
public class HeaderWidthManager
{
   private Dictionary<string, Dictionary<int, int>> lookupTable = new Dictionary<string, Dictionary<int, int>>();

   private string filePath = Directory.GetCurrentDirectory() + "\\ColumnWidths.csv";


   public HeaderWidthManager()
   {
      try
      {
         LoadData();

      }
      catch
      {
         lookupTable = new Dictionary<string, Dictionary<int, int>>();
      }

   }

   private void LoadData()
   {
      if (!File.Exists(filePath))
      {
         return;
      }

      Dictionary<string, Dictionary<int, int>> output = new Dictionary<string, Dictionary<int, int>>();

      string[] dataLines = File.ReadAllLines(filePath);

      foreach (string line in dataLines)
      {
         string[] fields = line.Split(',');

         string screenName = fields[0];
         string[] columnWidths = fields[1].Split(';');

         var screenColumns = new Dictionary<int, int>();

         foreach (string columnData in columnWidths)
         {
            string[] columnWidthFields = columnData.Split(':');

            int columnIndex = int.Parse(columnWidthFields[0]);
            int columnWidth = int.Parse(columnWidthFields[1]);

            screenColumns.Add(columnIndex, columnWidth);
         }


         output.Add(screenName, screenColumns);
      }

      lookupTable = output;
   }

   private void SaveData()
   {
      StringBuilder output = new StringBuilder();

      foreach (var screenName in lookupTable.Keys)
      {
         StringBuilder lineStringBuilder = new StringBuilder();

         lineStringBuilder.Append($"{screenName},");

         foreach (var columnName in lookupTable[screenName].Keys)
         {
            int columnWidth = lookupTable[screenName][columnName];

            lineStringBuilder.Append($"{columnName}:{columnWidth};");

         }

         lineStringBuilder.Remove(lineStringBuilder.Length - 1, 1);
         output.AppendLine(lineStringBuilder.ToString());
      }

      File.WriteAllText(filePath, output.ToString());
   }

   public void SetHeaderWidth(string screenName, int columnIndex, int width)
   {
      Dictionary<int, int> screenColumnWidths = new Dictionary<int, int>();

      if (!lookupTable.ContainsKey(screenName))
      {
         lookupTable.Add(screenName, screenColumnWidths);
      }

      screenColumnWidths = lookupTable[screenName];

      if (!screenColumnWidths.ContainsKey(columnIndex))
      {
         screenColumnWidths.Add(columnIndex, width);
      }

      screenColumnWidths[columnIndex] = width;

      SaveData();
   }

   public int GetHeaderWidth(string screenName, int columnIndex, int defaultWidth)
   {
      if (!lookupTable.ContainsKey(screenName))
      {
         return defaultWidth;
      }

      Dictionary<int, int> screenColumnWidths = lookupTable[screenName];

      if (!screenColumnWidths.ContainsKey(columnIndex))
      {
         return defaultWidth;
      }

      return screenColumnWidths[columnIndex];
   }

   public void LoadWidthsIntoColumns(ListView listView, string screenName)
   {
      ListView.ColumnHeaderCollection columns = listView.Columns;
      foreach (ColumnHeader c in columns)
      {
         int newWidth = GetHeaderWidth(screenName, c.Index, c.Width);
         c.Width = newWidth;
      }
   }
}
