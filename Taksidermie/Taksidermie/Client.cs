using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taksidermie
{
    class Client
    {

        private int ID;
        private string name;
        private string surname;
        private string cell;
        private string address;

        public int ID1 { get => ID; set => ID = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Cell { get => cell; set => cell = value; }
        public string Address { get => address; set => address = value; }

        public Client(int iD, string name, string surname, string cell, string address)
        {
            ID = iD;
            this.name = name;
            this.surname = surname;
            this.cell = cell;
            this.address = address;
        }
    }
}
