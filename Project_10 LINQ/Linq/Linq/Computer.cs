using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Computer
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int Ram { get; set; }
        public int Storage { get; set; }

        public Computer(string brand, string model, double price, int ram, int storage)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Ram = ram;
            Storage = storage;
        }

        public override string ToString()
        {
            return $"Brand: {Brand},\t {Model},\t {Price},\t {Ram},\t {Storage}";
        }
    }
}
