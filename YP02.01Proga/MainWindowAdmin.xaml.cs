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
    /// Логика взаимодействия для MainWindowAdmin.xaml
    /// </summary>
    public partial class MainWindowAdmin : Window
    {
        public MainWindowAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow cl = new ClientsWindow();
            cl.Show();
            this.Close();
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindow auth = new MainWindow();
            auth.Show();
            this.Close();
        }

        private void trener_click(object sender, RoutedEventArgs e)
        {
            WindowTrener trener = new WindowTrener();
            trener.Show();
            this.Close();
        }

        private void Abonements(object sender, RoutedEventArgs e)
        {
            WindowAbonements ab = new WindowAbonements();
            ab.Show();
            this.Close();
        }

        private void zaniatiya_click(object sender, RoutedEventArgs e)
        {
            WindowZaniyatia z = new WindowZaniyatia();
            z.Show();
            this.Close();
        }

        private void oplati_click(object sender, RoutedEventArgs e)
        {
            WindowOplati oplati = new WindowOplati();
            oplati.Show();
            this.Close();
        }

        private void groups_click(object sender, RoutedEventArgs e)
        {
            WindowGroups groups = new WindowGroups();
            groups.Show();
            this.Close();
        }

        private void tiptrenera_click(object sender, RoutedEventArgs e)
        {
            WindowTypeTrener t = new WindowTypeTrener();
            t.Show();
            this.Close();
        }

        private void sroki_click(object sender, RoutedEventArgs e)
        {
            WindowSrokiAbonements s = new WindowSrokiAbonements();
            s.Show();
            this.Close();
        }

        private void oblast_click(object sender, RoutedEventArgs e)
        {
            WindowOblastDeistviya ob = new WindowOblastDeistviya();
            ob.Show();
            this.Close();
        }
    }
}
