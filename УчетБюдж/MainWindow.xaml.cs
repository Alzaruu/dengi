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
        public MainWindow()
        {
            InitializeComponent();
            Tabliza.ItemsSource = dengi;

            DateTime dateTime = DateTime.Now;
            Calend.Text = dateTime.ToString();
            List<Serial> lll = Serial.MyDeser<List<Serial>>();
            foreach (Serial serial in lll)
            {
                items?.Append(serial.name);
            }
            Tabliza.ItemsSource = items;

        }
        string[] items;
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
            Serial.MySeriali<List<Serial>>(lll);
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            List<Serial> lll = Serial.MyDeser<List<Serial>>();
            foreach (Serial Serial in lll)
            {
                if ((Serial.name.Equals(Pis1.Text) || Serial.money.Equals(Convert.ToInt32(Pis2.Text)))
                    && Serial.data.Equals(Calend.Text))
                {
                    Serial.name = Pis1.Text;
                    Serial.money = Convert.ToInt32(Pis2.Text);
                }
            }
           Serial.MySeriali<List<Serial>>(lll);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var index = Tabliza.SelectedIndex;
            Tabliza.Items.RemoveAt(Tabliza.SelectedIndex);


            List<Serial> lll = Serial.MyDeser<List<Serial>>();
            foreach (Serial Serial in lll)
            {
                if ((Serial.name.Equals(Pis1.Text) || Serial.money.Equals(Convert.ToInt32(Pis2.Text)))
                    && Serial.data.Equals(Calend.Text))
                {
                    lll.Remove(Serial);
                }
            }
            Serial.MySeriali<List<Serial>>(lll);
        }

        private void AddType_Click(object sender, RoutedEventArgs e)
        {
            TYPEWindow1 window = new TYPEWindow1();
            window.ShowDialog();
            Spisok.Items.Add(window.textt);
        }

        private void Tabliza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UchetClass selected = Tabliza.SelectedItem as UchetClass;
        }
    }
}
