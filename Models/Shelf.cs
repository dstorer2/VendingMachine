using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

// Shelf is going to house the Candies. Shelf will contain the flavor attribute
// and candies will just go in a shelf that has their attribute.

// Had to add Shelf Index (A, B, C, or D) for main page interface


namespace VendingMachine.Models
{
    public class Shelf
    {
        [Key]
        public int ShelfId { get; set; }
        public char ShelfIndex { get; set; }
        public string Flavor { get; set; }
        public List<Candy> ShelvedCandyBars { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}