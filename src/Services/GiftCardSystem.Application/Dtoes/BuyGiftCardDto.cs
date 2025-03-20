using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Dtoes
{
    public class BuyGiftCardDto : GiftCardPurchaseDto
    {
        public decimal Amount { get; set; }
    }
}
