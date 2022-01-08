using System;
using System.Collections.Generic;


namespace Backend.Models{

    public class Location{

        public Guid Id { get; set; }
        public int Aisle { get; set; }

        public int Rack { get; set; }

        public int Shelf { get; set; }

        public int Bin { get; set; }


        public string FormatLocation(){
            //location format: 01-02-03-4 for aisle 1, rack 2, shelf 3, bin 4
            string aisleFormated = NumberOfDigits(this.Aisle) > 1 ? $"{this.Aisle}" : $"0{this.Aisle}";
            string rackFormated = NumberOfDigits(this.Rack) > 1 ? $"{this.Rack}" : $"0{this.Rack}";
            string shelfFormated = NumberOfDigits(this.Shelf) > 1 ? $"{this.Shelf}" : $"0{this.Shelf}";
            string binFormated = $"{this.Bin}";

            return $"{aisleFormated}-{rackFormated}-{shelfFormated}-{binFormated}";
        }


        protected int NumberOfDigits(int number){
            //retruns the number of digits in an integer. Will be used in "FormatLocation" function. 
            return (int) (Math.Log10(number) + 1); 
        }
    }
}