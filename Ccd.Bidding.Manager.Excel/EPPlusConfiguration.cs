using Ccd.Bidding.Manager.Win.Library;
using OfficeOpenXml;

namespace Ccd.Bidding.Manager.Excel;

public static class EpplusConfiguration
{
   public static void SetEpplusConfiguration(
      EpplusLicenseType licenseType,
      string? nonCommercialPersonalName = null,
      string? nonCommercialOrganizationName = null,
      string? commercialLicenseKey = null
   )
   {
      switch (licenseType)
      {
         case EpplusLicenseType.Commercial:
            if (string.IsNullOrEmpty(commercialLicenseKey))
            {
               return;
            }
            ConfigureCommercial(commercialLicenseKey);
            break;
         case EpplusLicenseType.NonCommercialPersonal:
            if (string.IsNullOrEmpty(nonCommercialPersonalName))
            {
               return;
            }
            ConfigureNonCommercialPersonal(nonCommercialPersonalName);
            break;
         case EpplusLicenseType.NonCommercialOrganization:
            if (string.IsNullOrEmpty(nonCommercialOrganizationName))
            {
               return;
            }
            ConfigureNonCommercialOrganization(nonCommercialOrganizationName);
            break;
         default:
            ExcelPackage.License.RemoveActiveLicense();
            break;
      }
   }

   private static void ConfigureCommercial(string commercialKey)
   {
      ExcelPackage.License.SetCommercial(commercialKey);
   }

   private static void ConfigureNonCommercialPersonal(string name)
   {
      ExcelPackage.License.SetNonCommercialPersonal(name);
   }

   private static void ConfigureNonCommercialOrganization(string organization)
   {
      ExcelPackage.License.SetNonCommercialOrganization(organization);
   }
}
