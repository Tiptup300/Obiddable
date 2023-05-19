using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding
{
    public class AccountNumber
    {
        private const string FormatTemplate = "xx.xxxx.xxx.xxx.xx.xx.xx.xxxx";

        public static bool IsInvalid(string accountNumber)
            => IsValid(accountNumber) == false;

        public static bool IsValid(string accountNumber)
        {
            if (accountNumber.Length != FormatTemplate.Length)
            {
                return false;
            }
            for (int i = 0; i < accountNumber.Length; i++)
            {
                if(accountNumberCharacterValid(accountNumber[i], FormatTemplate[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool accountNumberCharacterValid(char accountNumberChar, char templateChar)
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
