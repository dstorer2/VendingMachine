using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Creating Wrapper class to keep track of dispensed candy.
// No trash can. Will just pull wrappers by color from DB for "trash can" data
// Create wrapper when Candy is dispensed and decremented
// If wrapper exists in DB with wrapper color of dispensed candy, increase qty 1.
// Else create new wrapper

namespace VendingMachine.Models
{
    public class Wrapper
    {
        [Key]
        public int WrapperId { get; set; }
        public string WrapperColor { get; set; }
        public int Qty { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    } 
}