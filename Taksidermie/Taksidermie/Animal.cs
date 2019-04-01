using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taksidermie
{
    class Animal
    {

        private int tropheeid;
        private int clientid;
        private int amount;
        private string animals;
        private string tropheetype;
        private string remark;
        private double price;
        private double deposit;
        private bool paid;

        public int Tropheeid { get => tropheeid; set => tropheeid = value; }
        public int Clientid { get => clientid; set => clientid = value; }
        public int Amount { get => amount; set => amount = value; }
        public string Animals { get => animals; set => animals = value; }
        public string Tropheetype { get => tropheetype; set => tropheetype = value; }
        public string Remark { get => remark; set => remark = value; }
        public double Price { get => price; set => price = value; }
        public double Deposit { get => deposit; set => deposit = value; }
        public bool Paid { get => paid; set => paid = value; }

        public Animal(int tropheeid, int clientid, int amount, string animals, string tropheetype, string remark, double price, double deposit, bool paid)
        {
            this.tropheeid = tropheeid;
            this.clientid = clientid;
            this.amount = amount;
            this.animals = animals;
            this.tropheetype = tropheetype;
            this.remark = remark;
            this.price = price;
            this.deposit = deposit;
            this.paid = paid;
        }
    }
}
