using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// A given candy bar goes in a shelf that corresponds to their flavor. No validation
// for that, just going to leave it up to the user to accurately sort
// Any time a candy is dispensed from a shelf, it's qty will decrease one and 
// I'll create an instance of a wrapper.
// Candy needs qty attribute to tell Vending Machine dispense function if 
// it can be dispensed.
// Price in cents, INT 
// Wrapper color attribute to use to create wrapper upon dispense

namespace VendingMachine.Models{
    public class Candy
    {
        [Key]
        public int CandyId {get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string WrapperColor { get; set; }
        public int Qty { get; set; }
        public int ShelfId { get; set; }
        public Shelf ParentShelf { get; set; }
        public DateTime CreatedAt {get; set; } = DateTime.Now;
        public DateTime UpdatedAt {get; set; } = DateTime.Now;
    }
}