using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace УчетБюдж
{
    internal class Serial
    {
        public string name { get; set; }
        public string type { get; set; }
        public int money { get; set; }
        public bool postVich { get; set; } 
        public string data { get; set; }
        public static void MySeriali<T>(T serials)
        {
            string json = JsonConvert.SerializeObject(serials);
            File.WriteAllText("C:\\Users\\Tenru\\OneDrive\\Рабочий стол\\C#\\УчетБюдж\\УчетБюдж\\jsoon.json", json);
        }

        public static T MyDeser<T>()
        {
            string json = File.ReadAllText("C:\\Users\\Tenru\\OneDrive\\Рабочий стол\\C#\\УчетБюдж\\УчетБюдж\\jsoon.json");
            T serials = JsonConvert.DeserializeObject<T>(json);
            return serials;
        }
    }
}
