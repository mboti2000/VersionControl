using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSimulation.Entities
{
    public class Person
    {
        public int yearOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int numberOfChildren { get; set; }
        public bool isALive { get; set; }

        public Person()
        {
            isALive = true;
        }
    }

   

}
