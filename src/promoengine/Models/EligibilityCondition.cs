using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeekWeb.Models
{
    public class EligibilityCondition
    {
        public int EligibilityConditionId { get; set; }
        public Operand Operand { get; set; }
        public Operator Operator { get; set; }
        public string Value { get; set; }
        public Gate Gate { get; set; }
    }
    public enum Operand { Quantity, AdType, UserId }
    public enum Operator { GreaterThan, LessThan, Equals }
    public enum Gate { NONE, AND, OR }
}
