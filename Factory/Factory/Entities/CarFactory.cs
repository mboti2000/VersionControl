using Factory.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Entities
{
    public class CarFactory : IToyfactory
    {
        public Toy CreateNew() {
            return new Car();
        }
    }
}
