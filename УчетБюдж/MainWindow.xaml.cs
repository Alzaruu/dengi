using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace УчетБюдж
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<UchetClass> dengi = new List<UchetClass>();
        string[] items;
        public MainWindow()
        {
            InitializeComponent();
            Tabliza.ItemsSource = dengi;

            DateTime dateTime = DateTime.Now;
            Calend.Text = dateTime.ToString();
            List<Serial> list = Serial.MyDeser<List<Serial>>();
            for (int i = 0; i < list.Count;i++) {
                
            }
            foreach (Serial serial in list)
            {
                items?.Append(serial.name);
            }
            Tabliza.ItemsSource = items;

        }
        /*string nname;
        int mmon;
        string ttype;
        string ddate;*/

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            /*ddate = (Calend.SelectedDate).ToString();
            ttype = (Spisok.SelectedItem).ToString();
            string nname = Pis1.Text;
            string pr = Pis2.Text;
            mmon = Convert.ToInt32(pr);
            dengi.Add(new UchetClass(nname,ttype,mmon,ddate));
            Tabliza.ItemsSource = dengi;*/

            List<Serial> lll = Serial.MyDeser<List<Serial>>();
            Serial lala = new Serial();
            lala.name = Pis1.Text;
            lala.type = (Spisok.SelectedItem).ToString();
            lala.money = Convert.ToInt32(Pis2.Text);
            DateTime ddata = Convert.ToDateTime(Calend.Text);
            lala.data = ddata.ToShortDateString();
            lll.Add(lala);
            Serial.MySeriali(lll);
            foreach (Serial Serial in lll.ToList())
            {
                if (Serial.data == Calend.DisplayDate.ToString())
                {
                    Serial.name = Pis1.Text;
                    Serial.money = Convert.ToInt32(Pis2.Text);
                }
            }
            Tabliza.ItemsSource = lll;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            List<Serial> lll = Serial.MyDeser<List<Serial>>();

            foreach ( Serial serial in lll.ToList())
            {
                if (serial.name == Pis1.Text || serial.money.ToString() == Pis2.Text)
                {
                    serial.name= Pis1.Text;
                    serial.money= Convert.ToInt32(Pis2.Text);
                }
            }
            Serial.MySeriali(lll);
            Tabliza.ItemsSource = lll;
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var index = Tabliza.SelectedIndex;
            Tabliza.Items.RemoveAt(Tabliza.SelectedIndex);
            List<Serial> lll = Serial.MyDeser<List<Serial>>();
            foreach (Serial Serial in lll.ToList())
            {
                if (Serial.data == Calend.DisplayDate.ToString())
                {
                    lll.Remove(Serial);
                }
            }
            Serial.MySeriali(lll);
            Tabliza.ItemsSource = lll;
        }

        private void AddType_Click(object sender, RoutedEventArgs e)
        {
            TYPEWindow1 window = new TYPEWindow1();
            window.ShowDialog();
            Spisok.Items.Add(window.textt);
        }

        private void Tabliza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UchetClass? selected = Tabliza.SelectedItem as UchetClass;
            List<Serial> lll = Serial.MyDeser<List<Serial>>();
            if (selected != null)
            {
                foreach (Serial Serial in lll.ToList())
                {
                    if (Serial.data == Calend.DisplayDate.ToString())
                    {
                        Serial.name = Pis1.Text;
                        Serial.money = Convert.ToInt32(Pis2.Text);
                    }
                }
            }
            Serial.MySeriali(lll);
            Tabliza.ItemsSource = lll;
        }

        private void Calend_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Serial> lll = Serial.MyDeser<List<Serial>>();
            var meow = new List<Serial>();
            foreach (Serial serial in lll.ToList())
            {
                if (serial.data == Calend.SelectedDate.ToString())
                {
                    meow.Add(serial);
                    Tabliza.ItemsSource = meow;
                }
            }
        }
    }
}
