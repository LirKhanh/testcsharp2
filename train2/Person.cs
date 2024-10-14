using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train2
{
    internal class Person
    {
        private string name;
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return this.name;
        }
        private string address;
        public void setAddress(string address)
        {
            this.address = address;
        }
        public string getAddress()
        {
            return this.address;
        }
        public Person() { }
        public Person(string name, string address)
        { 
            this.name = name;
            this.address = address;
        }
    }
}
