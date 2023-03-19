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
using System.Windows.Shapes;

namespace УчетБюдж
{
    /// <summary>
    /// Логика взаимодействия для TYPEWindow1.xaml
    /// </summary>
    public partial class TYPEWindow1 : Window
    {
        public TYPEWindow1()
        {
            InitializeComponent();
        }
        public string textt;
        private void DobType_Click(object sender, RoutedEventArgs e)
        {
            textt = TypeText.Text;
            DialogResult = true;
        }
    }
}
