namespace Ccd.Bidding.Manager.Library.Bidding
{
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
         if (arePeriods(accountNumberChar, templateChar) ||
             areFillerSpace(accountNumberChar, templateChar))
         {
            return true;
         }
         else
         {
            return false;
         }
      }
      private static bool arePeriods(char accountNumberChar, char templateChar)
          => isPeriod(accountNumberChar) && isPeriod(templateChar);

      private static bool isPeriod(char character)
          => character == '.';

      private static bool areFillerSpace(char accountNumberChar, char templateChar)
          => isNumber(accountNumberChar) && isFiller(templateChar);

      private static bool isNumber(char character)
          => (character >= '0' && character <= '9');
      private static bool isFiller(char character)
          => character == 'x';
   }
}
