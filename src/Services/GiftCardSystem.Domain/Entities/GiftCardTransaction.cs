using GiftCardSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Domain.Entities
{
    public class GiftCardTransaction : EntityBase
    {
        public int GiftCardPurchaseId { get; set; }
        public virtual GiftCardPurchase GiftCardPurchase { get; set; }
        public decimal Amount { get; set; }
        public int Type { get; set; }
    }
}
