using Ccd.Bidding.Manager.Win.Library;

namespace Ccd.Bidding.Manager.Win.UI;

public partial class ConfigForm : Form
{
   public ConfigForm()
   {
      InitializeComponent();

      SetControlValues(UserConfiguration.Instance);

      UpdateEpplusTextBoxes();

      IsDataValid();
   }

   private bool IsDataValid()
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

      if (
         SelectedEpplusLicenseType == EpplusLicenseType.NonCommercialPersonal
         && epplusNonCommercialPersonalNameTextBox.Text.Trim().Length <= 0
      )
      {
         errorProvider1.SetError(
            epplusNonCommercialPersonalNameTextBox,
            "Please enter your name for the EPPlus license."
         );
         return false;
      }

      if (
         SelectedEpplusLicenseType == EpplusLicenseType.NonCommercialOrganization
         && epplusNonCommercialOrganizationNameTextBox.Text.Trim().Length <= 0
      )
      {
         errorProvider1.SetError(
            epplusNonCommercialOrganizationNameTextBox,
            "Please enter your organization name for the EPPlus license."
         );
         return false;
      }

      if (
         SelectedEpplusLicenseType == EpplusLicenseType.Commercial
         && epplusCommercialPaidLicenseKeyTextBox.Text.Trim().Length <= 0
      )
      {
         errorProvider1.SetError(
            epplusCommercialPaidLicenseKeyTextBox,
            "Please enter your EPPlus commercial license key."
         );
         return false;
      }

      return true;
   }

   private void OnSaveChangesClicked(object sender, EventArgs e)
   {
      if (IsDataValid())
      {
         DialogResult = DialogResult.OK;

         SaveConfigurationValues();

         Close();
      }
   }

   private void SetControlValues(UserConfiguration userConfiguration)
   {
      reportsFolderTextBox.Text = userConfiguration.DefaultReportsDirectory.FullName;
      exportsFolderTextBox.Text = userConfiguration.DefaultExportsDirectory.FullName;
      allowBidDeletionCheckBox.Checked = userConfiguration.CanDeleteBid;
      suppressFilePathSelectionsOnSavingCheckBox.Checked =
         userConfiguration.SupressFileLocationSelectDialog;
      autoOpenExportsCheckBox.Checked = userConfiguration.AutoOpenExports;
      autoOpenReportsCheckBox.Checked = userConfiguration.AutoOpenReports;
      includeTimestampsOnAllFiles.Checked = userConfiguration.IncludeTimestampsOnAllFiles;

      switch (userConfiguration.EpplusLicenseType)
      {
         case EpplusLicenseType.NonCommercialPersonal:
            epplusLicenseNonCommercialPersonalRadio.Checked = true;
            break;
         case EpplusLicenseType.NonCommercialOrganization:
            epplusLicenseNonCommercialOrganizationRadio.Checked = true;
            break;
         case EpplusLicenseType.Commercial:
            epplusLicenseCommercialPaidRadio.Checked = true;
            break;
         default:
            epplusNoLicenseRadio.Checked = true;
            break;
      }

      //SelectedEpplusLicenseType = userConfiguration.EpplusConfig.LicenseType;
      epplusNonCommercialPersonalNameTextBox.Text =
         userConfiguration.EpplusNonCommercialPersonalName;
      epplusNonCommercialOrganizationNameTextBox.Text =
         userConfiguration.EpplusNonCommercialOrganizationName;
      epplusCommercialPaidLicenseKeyTextBox.Text = userConfiguration.EpplusCommercialLicenseKey;
   }

   private void SaveConfigurationValues()
   {
      UserConfiguration.Instance.DefaultReportsDirectory = new DirectoryInfo(
         reportsFolderTextBox.Text
      );
      UserConfiguration.Instance.DefaultExportsDirectory = new DirectoryInfo(
         exportsFolderTextBox.Text
      );
      UserConfiguration.Instance.CanDeleteBid = allowBidDeletionCheckBox.Checked;
      UserConfiguration.Instance.SupressFileLocationSelectDialog =
         suppressFilePathSelectionsOnSavingCheckBox.Checked;
      UserConfiguration.Instance.AutoOpenExports = autoOpenExportsCheckBox.Checked;
      UserConfiguration.Instance.AutoOpenReports = autoOpenReportsCheckBox.Checked;
      UserConfiguration.Instance.IncludeTimestampsOnAllFiles = includeTimestampsOnAllFiles.Checked;

      UserConfiguration.Instance.EpplusLicenseType = SelectedEpplusLicenseType;

      UserConfiguration.Instance.EpplusNonCommercialPersonalName =
         SelectedEpplusLicenseType == EpplusLicenseType.NonCommercialPersonal
            ? epplusNonCommercialPersonalNameTextBox.Text.Trim()
            : null;
      UserConfiguration.Instance.EpplusNonCommercialOrganizationName =
         SelectedEpplusLicenseType == EpplusLicenseType.NonCommercialOrganization
            ? epplusNonCommercialOrganizationNameTextBox.Text.Trim()
            : null;
      UserConfiguration.Instance.EpplusCommercialLicenseKey =
         SelectedEpplusLicenseType == EpplusLicenseType.Commercial
            ? epplusCommercialPaidLicenseKeyTextBox.Text.Trim()
            : null;
   }

   private void OnCancelClicked(object sender, EventArgs e)
   {
      cancelButton.ToString();
      DialogResult = DialogResult.Cancel;
      Close();
   }

   private void OnKeyDown(object sender, KeyEventArgs e)
   {
      if (e.KeyCode == Keys.Enter)
      {
         OnSaveChangesClicked(sender, e);
      }

      if (e.KeyCode == Keys.Escape)
      {
         OnCancelClicked(sender, e);
      }
   }

   private void OnBrowseReportsFolderClicked(object sender, EventArgs e)
   {
      using (
         FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog()
         {
            SelectedPath = reportsFolderTextBox.Text,
         }
      )
      {
         if (folderSelectDialog.ShowDialog() != DialogResult.OK)
         {
            return;
         }
         reportsFolderTextBox.Text = folderSelectDialog.SelectedPath;
      }
   }

   private void ExportsFolderButton_Click(object sender, EventArgs e)
   {
      using (
         FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog()
         {
            SelectedPath = exportsFolderTextBox.Text,
         }
      )
      {
         if (folderSelectDialog.ShowDialog() != DialogResult.OK)
         {
            return;
         }
         exportsFolderTextBox.Text = folderSelectDialog.SelectedPath;
      }
   }

   private void OnEpplusLicensingLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
   {
      UrlOpener urlOpener = new UrlOpener();
      urlOpener.OpenUrl(@"https://polyformproject.org/licenses/noncommercial/1.0.0/");
   }

   private void OnEpplusLicenseSelectionChanged(object sender, EventArgs e) =>
      UpdateEpplusTextBoxes();

   public EpplusLicenseType SelectedEpplusLicenseType
   {
      get
      {
         if (epplusLicenseNonCommercialPersonalRadio.Checked)
         {
            return EpplusLicenseType.NonCommercialPersonal;
         }
         else if (epplusLicenseNonCommercialOrganizationRadio.Checked)
         {
            return EpplusLicenseType.NonCommercialOrganization;
         }
         else if (epplusLicenseCommercialPaidRadio.Checked)
         {
            return EpplusLicenseType.Commercial;
         }
         else
         {
            return EpplusLicenseType.None;
         }
      }
   }

   private void UpdateEpplusTextBoxes()
   {
      epplusNonCommercialPersonalNameTextBox.Enabled =
         SelectedEpplusLicenseType == EpplusLicenseType.NonCommercialPersonal;

      epplusNonCommercialOrganizationNameTextBox.Enabled =
         SelectedEpplusLicenseType == EpplusLicenseType.NonCommercialOrganization;

      epplusCommercialPaidLicenseKeyTextBox.Enabled =
         SelectedEpplusLicenseType == EpplusLicenseType.Commercial;
   }
}
