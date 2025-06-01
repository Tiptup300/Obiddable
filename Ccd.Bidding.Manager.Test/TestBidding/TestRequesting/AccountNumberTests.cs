using Ccd.Bidding.Manager.Library.Bidding;

namespace Ccd.Bidding.Manager.Test.Bidding.Requesting;
public class AccountNumberTests
{
   [Theory]
   [InlineData("invalid text")]
   [InlineData("xx.xxxx.xxx.xxx.xx.xx.xx.xxxx")]
   [InlineData("12.2222.222.222.11.33.44.232a")]
   [InlineData("12.2222.222.222.11.33.44.2324a")]
   public void InvalidAccountNumbersDontWork(string accountNumber)
   {
      Assert.True(AccountNumber.IsInvalid(accountNumber), $"AccountNumber {accountNumber} Is Invalid");
   }

   [Theory]
   [InlineData("12.2222.222.222.11.33.44.2324")]
   [InlineData("11.1111.111.444.11.33.44.2324")]
   public void ValidAccountNumbersWork(string accountNumber)
   {
      Assert.True(AccountNumber.IsValid(accountNumber), $"AccountNumber {accountNumber} Is Valid");
   }
}
