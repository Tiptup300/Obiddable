using Ccd.Bidding.Manager.Win.Library;
using System;
using System.IO;
using System.Windows.Forms;

namespace Ccd.Bidding.Manager.Win.UI
{
   public partial class ConfigForm : Form
   {
      public ConfigForm()
      {
         InitializeComponent();

         setConfigurationValues(UserConfiguration.Instance);

         dataIsValid();
      }

      #region DATA VALIDATION METHOD
      private bool dataIsValid()
      {
         errorProvider1.Clear();
         DirectoryInfo reportFolderDirectory = new DirectoryInfo(reportsFolderTextBox.Text);
         if (!reportFolderDirectory.Exists)
         {
            errorProvider1.SetError(reportsFolderTextBox, "Report folder does not exist");
            return false;
         }

         DirectoryInfo exportFolderDirectory = new DirectoryInfo(exportsFolderTextBox.Text);
         if (!exportFolderDirectory.Exists)
         {
            errorProvider1.SetError(exportsFolderTextBox, "Export folder does not exist");
            return false;
         }

         return true;
      }
      #endregion

      #region BUTTON EVENTS
      private void savechangesButton_Click(object sender, EventArgs e)
      {
         if (dataIsValid())
         {
            DialogResult = DialogResult.OK;

            SaveConfigurationValues();

            Close();
         }
      }

      private void setConfigurationValues(UserConfiguration userConfiguration)
      {
         reportsFolderTextBox.Text = userConfiguration.DefaultReportsDirectory.FullName;
         exportsFolderTextBox.Text = userConfiguration.DefaultExportsDirectory.FullName;
         allowBidDeletionCheckBox.Checked = userConfiguration.CanDeleteBid;
         suppressFilePathSelectionsOnSavingCheckBox.Checked = userConfiguration.SupressFileLocationSelectDialog;
         autoOpenExportsCheckBox.Checked = userConfiguration.AutoOpenExports;
         autoOpenReportsCheckBox.Checked = userConfiguration.AutoOpenReports;
         includeTimestampsOnAllFiles.Checked = userConfiguration.IncludeTimestampsOnAllFiles;
      }

      private void SaveConfigurationValues()
      {
         UserConfiguration.Instance.DefaultReportsDirectory = new DirectoryInfo(reportsFolderTextBox.Text);
         UserConfiguration.Instance.DefaultExportsDirectory = new DirectoryInfo(exportsFolderTextBox.Text);
         UserConfiguration.Instance.CanDeleteBid = allowBidDeletionCheckBox.Checked;
         UserConfiguration.Instance.SupressFileLocationSelectDialog = suppressFilePathSelectionsOnSavingCheckBox.Checked;
         UserConfiguration.Instance.AutoOpenExports = autoOpenExportsCheckBox.Checked;
         UserConfiguration.Instance.AutoOpenReports = autoOpenReportsCheckBox.Checked;
         UserConfiguration.Instance.IncludeTimestampsOnAllFiles = includeTimestampsOnAllFiles.Checked;
      }

      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
         Close();
      }
      #endregion

      private void BidEditDialog_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            savechangesButton_Click(sender, e);
         }

         if (e.KeyCode == Keys.Escape)
         {
            toolStripButton1_Click(sender, e);
         }
      }

      private void reportsFolderButton_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog()
         {
            SelectedPath = reportsFolderTextBox.Text,
         })
         {
            if (folderSelectDialog.ShowDialog() != DialogResult.OK)
            {
               return;
            }
            reportsFolderTextBox.Text = folderSelectDialog.SelectedPath;
         }
      }

      private void exportsFolderButton_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog()
         {
            SelectedPath = exportsFolderTextBox.Text,
         })
         {
            if (folderSelectDialog.ShowDialog() != DialogResult.OK)
            {
               return;
            }
            exportsFolderTextBox.Text = folderSelectDialog.SelectedPath;
         }
      }
   }
}
