using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Constants
{
    public class ConstantsItems
    {
        public static string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string PhoneNumberRegex = @"^\+[1-9]\d{1,14}$";
    }
}
