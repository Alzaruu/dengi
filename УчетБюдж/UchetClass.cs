using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетБюдж
{
    class UchetClass
    {
        public string name { get; set; }
        public string type { get; set; }
        public int money {
            get { return money; }
            set
            {
                money = value;
                if (money< 0) { postVich = false; }
                else { postVich = true; }
            }
        }
        public string data { set { } }
        public bool postVich { get; set; }

        public UchetClass(string Name, string Type, int Money, string Data) {
            name = Name;
            type = Type;
            money = Money;
            data = Data;
            money= Money;
            if (money < 0) { postVich=false; } 
            else { postVich = true; }
        }
    }
}
