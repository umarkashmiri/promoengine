using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeekWeb.Models
{
    public class EligibilityCriteria
    {
        public int EligibilityCriteriaId { get; set; }
        public ICollection<EligibilityCondition> Conditions { get; set; }
        public Discount Discount { get; set; }
    }
}
