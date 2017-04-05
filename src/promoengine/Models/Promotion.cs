using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeekWeb.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public string PromoName { get; set; }
        public EligibilityCriteria EligibilityCriteria { get; set; }
    }
}
