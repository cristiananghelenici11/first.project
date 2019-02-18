using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{

    internal class Phone
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        readonly int? _ram = null;
        readonly int? _capacity = null;

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
