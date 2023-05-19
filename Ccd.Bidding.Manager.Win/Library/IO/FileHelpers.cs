using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Ccd.Bidding.Manager.Reporting;
using Ccd.Bidding.Manager.Win.UI;

namespace Ccd.Bidding.Manager.Win.Library.IO
{
    public static class FileHelpers
    {

        #region SAVES
        public static void SaveReport(IReportFile reportFile, bool supressDialog)
        {
            string initialFileName = reportFile.FileName.MakeValidFileName();
            string initialDirectory = UserConfiguration.Instance.DefaultReportsDirectory.FullName;
            string dialogTitle = "Save Report";
            string extension = "html";
            string fileName = ShowSaveFileDialog(initialDirectory, dialogTitle, extension, initialFileName, supressDialog);
            if (fileName is null)
            {
                return;
            }

            string data = reportFile.Data;

            TryUntilFileUnlocked(fileName);

            File.WriteAllText(fileName, data);
            if (UserConfiguration.Instance.AutoOpenReports)
            {
                System.Diagnostics.Process.Start(fileName);
            }
        }
        public static void SaveCSV(string initialFileName, string data, string dialogTitle, bool supressDialog)
        {
            string initialDirectory = UserConfiguration.Instance.DefaultExportsDirectory.FullName;
            string extension = "csv";
            string fileName = ShowSaveFileDialog(initialDirectory, dialogTitle, extension, initialFileName, supressDialog);
            if (fileName is null)
            {
                return;
            }

            TryUntilFileUnlocked(fileName);
            File.WriteAllText(fileName, data);
            if (UserConfiguration.Instance.AutoOpenExports)
            {
                System.Diagnostics.Process.Start(fileName);
            }
        }

        public static void SaveExcel(string initialFileName, MemoryStream stream, string dialogTitle, bool supressDialog)
        {
            string initialDirectory = UserConfiguration.Instance.DefaultExportsDirectory.FullName;
            string extension = "xlsx";

            string fileName = ShowSaveFileDialog(initialDirectory, dialogTitle, extension, initialFileName, supressDialog);
            if (fileName is null)
            {
                return;
            }

            TryUntilFileUnlocked(fileName);
            using (FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                stream.WriteTo(file);
            }
            if (UserConfiguration.Instance.AutoOpenExports)
            {
                System.Diagnostics.Process.Start(fileName);
            }

        }
        public static void SaveExcels(string[] fileNames, MemoryStream[] streams, string dialogDescription)
        {
            if (fileNames.Length != streams.Length)
            {
                return;
            }
            string selectedPath = UserConfiguration.Instance.DefaultExportsDirectory.FullName;
            string folderPath = ShowFolderBrowserDialog(selectedPath, dialogDescription);
            if (folderPath is null)
            {
                return;
            }

            foreach (string fileName in fileNames)
            {
                TryUntilFileUnlocked(folderPath + "\\" + fileName);
            }

            for (int x = 0; x < fileNames.Length; x++)
            {
                using (FileStream file = new FileStream(folderPath + "\\" + fileNames[x], FileMode.Create, FileAccess.Write))
                {
                    streams[x].WriteTo(file);
                }
            }

            if (UserConfiguration.Instance.AutoOpenExports)
            {
                System.Diagnostics.Process.Start(folderPath);
            }

        }
        public static string ShowSaveFileDialog(string initialDirectory, string dialogTitle, string extension, string initialFileName, bool supressDialog)
        {
            if (supressDialog)
            {
                return initialDirectory + "\\" + initialFileName;
            }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                InitialDirectory = initialDirectory,
                Title = dialogTitle,
                CheckPathExists = true,
                FileName = initialFileName,
                DefaultExt = extension,
                Filter = $"{ extension } files (*.{ extension })|*.{ extension }",
                FilterIndex = 2,
                RestoreDirectory = true,
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }
                return saveFileDialog.FileName;
            }
        }
        public static string ShowFolderBrowserDialog(string selectedPath, string dialogDescription)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                SelectedPath = selectedPath,
                Description = dialogDescription,
                ShowNewFolderButton = true
            })
            {
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }
                return folderBrowserDialog.SelectedPath;
            }
        }
        #endregion

        #region OPENS
        public static string OpenFile(string dialogTitle, string extension)
        {
            string initalDirectory = UserConfiguration.Instance.DefaultExportsDirectory.FullName;

            string fileName = ShowOpenFileDialog(initalDirectory, dialogTitle, extension);
            if (fileName is null)
            {
                return null;
            }

            if (!File.Exists(fileName))
            {
                FilesMessaging.Instance.ShowFileCantBeLocatedError(fileName);
                return null;
            }


            TryUntilFileUnlocked(fileName);

            return fileName;
        }
        public static string ShowOpenFileDialog(string initialDirectory, string dialogTitle, string extension)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = initialDirectory,

                CheckFileExists = true,
                CheckPathExists = true,

                Title = dialogTitle,

                DefaultExt = extension,
                Filter = $"{ extension } files (*.{ extension })|*.{ extension }",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            })
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }
                return openFileDialog.FileName;
            }
        }
        #endregion

        public static string MakeValidFileName(this string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(name.Replace(" ", "_"), invalidRegStr, "_");
        }
        public static bool IsFileLocked(string filePath)
        {
            try
            {
                using (File.Open(filePath, FileMode.Open)) { }
            }
            catch (IOException e)
            {
                var errorCode = Marshal.GetHRForException(e) & (1 << 16) - 1;

                return errorCode == 32 || errorCode == 33;
            }

            return false;
        }
        public static void TryUntilFileUnlocked(string fileName)
        {
            while (IsFileLocked(fileName))
            {
                if (FilesMessaging.Instance.ConfirmRetryFileLocked(fileName) == false)
                {
                    return;
                }
            }
        }
        public static string[] ParseCSVRow(string csvrow)
        {
            //Define pattern
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            string[] results = CSVParser.Split(csvrow);

            for (int x = 0; x < results.Length; x++)
            {
                results[x] = results[x].Replace("[DOUBLE-QUOTE]", "\"");
            }

            //Separating columns to array
            return results.ToList().Select(x => x.RemoveApostrophes()).ToArray();
        }
        public static string RemoveApostrophes(this string str)
        {
            if (str.Length < 2)
            {
                return str;
            }

            if (str[0] == '"' && str[str.Length - 1] == '"')
            {
                return str.Substring(1, str.Length - 2);
            }

            return str;
        }
    }
}
