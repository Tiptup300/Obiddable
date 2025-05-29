using Ccd.Bidding.Manager.Library;
using Ccd.Bidding.Manager.Win.Library.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Ccd.Bidding.Manager.Win.Library
{
   public class UserConfiguration
   {
      public static UserConfiguration Instance;
      private const string _configCSVHeader = "property,value";


      private static string _configFileName;
      private int? _workingBidId;
      private bool _includeTimestampsOnAllFiles = true;
      private bool _autoOpenExports = true;
      private bool _autoOpenReports = true;
      private bool _canDeleteBid = false;
      private bool _supressFileLocationSelectDialog = true;
      private string _helpUrl = "http://10.10.0.19/";
      private DirectoryInfo _defaultReportsDirectory = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Reports");
      private DirectoryInfo _defaultExportsDirectory = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Exports");


      public int? WorkingBidId
      {
         get { return _workingBidId; }
         set
         {
            _workingBidId = value;
            SaveConfigurationFile();
         }
      }
      public bool AutoOpenExports
      {
         get { return _autoOpenExports; }
         set
         {
            _autoOpenExports = value;
            SaveConfigurationFile();
         }
      }
      public bool AutoOpenReports
      {
         get { return _autoOpenReports; }
         set
         {
            _autoOpenReports = value;
            SaveConfigurationFile();
         }
      }
      public bool CanDeleteBid
      {
         get { return _canDeleteBid; }
         set
         {
            _canDeleteBid = value;
            SaveConfigurationFile();
         }
      }
      public bool SupressFileLocationSelectDialog
      {
         get { return _supressFileLocationSelectDialog; }
         set
         {
            _supressFileLocationSelectDialog = value;
            SaveConfigurationFile();
         }
      }
      public bool IncludeTimestampsOnAllFiles
      {
         get { return _includeTimestampsOnAllFiles; }
         set
         {
            _includeTimestampsOnAllFiles = value;
            SaveConfigurationFile();
         }
      }
      public string HelpUrl
      {
         get => _helpUrl;
         set
         {
            _helpUrl = value;
            SaveConfigurationFile();
         }
      }
      public DirectoryInfo DefaultReportsDirectory
      {
         get { return _defaultReportsDirectory; }
         set
         {
            _defaultReportsDirectory = value;
            SaveConfigurationFile();
         }
      }
      public DirectoryInfo DefaultExportsDirectory
      {
         get { return _defaultExportsDirectory; }
         set
         {
            _defaultExportsDirectory = value;
            SaveConfigurationFile();
         }
      }


      public UserConfiguration(string configFileName)
      {
         _configFileName = configFileName;
         LoadConfigurationFile();
      }

      private void LoadConfigurationFile()
      {
         if (isConfigFileNotCreated())
         {
            SaveConfigurationFile();
         }
         if (isConfigFileLocked())
         {
            // use defaults
            return;
         }
         loadCsvFile();
      }
      private static bool isConfigFileNotCreated()
      {
         return !File.Exists(_configFileName);
      }
      private static bool isConfigFileLocked()
      {
         return FileHelpers.IsFileLocked(_configFileName);
      }

      private void loadCsvFile()
      {
         string[] fileData = File.ReadAllLines(_configFileName);
         if (fileData[0].ToLower().Trim() != _configCSVHeader)
         {
            SaveConfigurationFile();
            return;
         }

         fileData
             .Skip(1)
             .Select(readLine())
             .Where(isValidLine())
             .ToList()
             .ForEach(setFieldValue());
      }
      private Func<string, CsvFieldLine> readLine()
      {
         return line =>
         {
            if (line.Trim() == "")
            {
               return CsvFieldLine.Null;
            }
            string[] fields = FileHelpers.ParseCSVRow(line);
            return new CsvFieldLine(fields[0], fields[1]);
         };
      }
      private Func<CsvFieldLine, bool> isValidLine()
      {
         return csvFieldLine =>
         {
            return csvFieldLine != CsvFieldLine.Null;
         };
      }
      private Action<CsvFieldLine> setFieldValue()
      {
         return fieldLine =>
         {

            FieldInfo fieldInfo = getFieldByName(fieldLine.Name);

            object valueToSet;

            if (fieldInfo is null)
            {
               return;
            }
            if (fieldInfo.FieldType == typeof(bool))
            {
               valueToSet = bool.Parse(fieldLine.Value);
            }
            else if (fieldInfo.FieldType == typeof(int))
            {
               valueToSet = int.Parse(fieldLine.Value);
            }
            else if (fieldInfo.FieldType == typeof(DirectoryInfo))
            {
               DirectoryInfo directoryInfo = new DirectoryInfo(fieldLine.Value);
               //if (directoryInfo.Exists == false)
               //{
               //throw new Exception($"Invalid Directory {fieldLine.Value} set for field {fieldInfo.Name}");
               //}
               valueToSet = directoryInfo;
            }
            else if (fieldInfo.FieldType == typeof(string))
            {
               valueToSet = fieldLine.Value;
            }
            else if (fieldInfo.FieldType == typeof(int?))
            {
               int number = 0;
               if (int.TryParse(fieldLine.Value, out number))
               {
                  valueToSet = number;
               }
               else
               {
                  valueToSet = null;
               }
            }
            else
            {
               throw new Exception($"Field {fieldInfo.Name} is not of a valid savable type.");
            }

            fieldInfo.SetValue(this, valueToSet);
         };
      }
      private FieldInfo getFieldByName(string fieldName)
      {
         return GetType()
             .GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
      }


      private void SaveConfigurationFile()
      {
         if (FileHelpers.IsFileLocked(_configFileName))
         {
            // if locked, dont save
            return;
         }

         var output = getNonPublicInstanceFields()
             .Select(writeLine())
             .Prepend(_configCSVHeader)
             .JoinAsLines();

         File.WriteAllText(_configFileName, output);
      }
      private IEnumerable<FieldInfo> getNonPublicInstanceFields()
      {
         return GetType()
             .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
      }
      private Func<FieldInfo, string> writeLine()
      {
         return field => $"{field.Name},{field.GetValue(this)?.ToString()}";
      }



      private class CsvFieldLine
      {
         public CsvFieldLine(string name, string value)
         {
            Name = name;
            Value = value;
         }

         public static CsvFieldLine Null { get; } = new CsvFieldLine(null, null);
         public string Name { get; private set; }
         public string Value { get; private set; }
      }
   }
}
