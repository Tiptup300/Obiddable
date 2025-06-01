namespace Ccd.Bidding.Manager.Library.Bidding;

public class AccountNumber
{
   public const string FORMAT = "xx.xxxx.xxx.xxx.xx.xx.xx.xxxx";

   public static bool IsInvalid(string accountNumber)
       => IsValid(accountNumber) == false;

   public static bool IsValid(string accountNumber)
   {
      if (accountNumber.Length != FORMAT.Length)
      {
         return false;
      }
      for (int i = 0; i < accountNumber.Length; i++)
      {
         if (AccountNumberCharacterValid(accountNumber[i], FORMAT[i]) == false)
         {
            return false;
         }
      }
      return true;
   }

   private static bool AccountNumberCharacterValid(char accountNumberChar, char templateChar)
   {
      if (ArePeriods(accountNumberChar, templateChar) ||
          AreFillerSpace(accountNumberChar, templateChar))
      {
         return true;
      }
      else
      {
         return false;
      }
   }
   private static bool ArePeriods(char accountNumberChar, char templateChar)
       => IsPeriod(accountNumberChar) && IsPeriod(templateChar);

   private static bool IsPeriod(char character)
       => character == '.';

   private static bool AreFillerSpace(char accountNumberChar, char templateChar)
       => IsNumber(accountNumberChar) && IsFiller(templateChar);

   private static bool IsNumber(char character)
       => (character >= '0' && character <= '9');
   private static bool IsFiller(char character)
       => character == 'x';
}
