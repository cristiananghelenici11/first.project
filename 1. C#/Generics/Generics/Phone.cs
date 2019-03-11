using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{

    public class Phone
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        private readonly int? _ram;
        private readonly int? _capacity;

        public Phone(string brand, string model, int? ram, int? capacity)
        {
            Brand = brand;
            Model = model;
            _ram = ram;
            _capacity = capacity;
        }

        public override string ToString()
        {
            return $"Brand: {Brand},\t Model: {Model},\t RAM: {_ram?? 0} MB,\t \tCapacity: {_capacity ?? 0} GB,";
        }
    }
}
