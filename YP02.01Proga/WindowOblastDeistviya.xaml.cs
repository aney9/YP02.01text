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

namespace YP02._01Proga
{
    /// <summary>
    /// Логика взаимодействия для WindowOblastDeistviya.xaml
    /// </summary>
    public partial class WindowOblastDeistviya : Window
    {
        public WindowOblastDeistviya()
        {
            InitializeComponent();
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindowAdmin adm = new MainWindowAdmin();
            adm.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
