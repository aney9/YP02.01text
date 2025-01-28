using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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
using System.Xml.Linq;

namespace YP02._01Proga
{
    /// <summary>
    /// Логика взаимодействия для WindowOplati.xaml
    /// </summary>
    public partial class WindowOplati : Window
    {
        private ProFormEntities c = new ProFormEntities();
        public WindowOplati()
        {
            InitializeComponent();
            dg.ItemsSource = c.Oplati1Set.ToList();
            vyborC.ItemsSource = c.Clients1Set.ToList();
            vyborC.DisplayMemberPath = "ClientSurname";
            vyborC.SelectedValuePath = "ID_Client";
            data.SelectedDate = DateTime.Today;
            int codee = GenerateUniqueCode();
            code.Text = codee.ToString();
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindowAdmin adm = new MainWindowAdmin();
            adm.Show();
            this.Close();
        }

        private void dg_select(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Oplati1)dg.SelectedItem;
            if (proverka != null) 
            {
                vyborC.SelectedValue = proverka.Client_ID;
                data.SelectedDate = DateTime.Parse(proverka.DateOplati);
                code.Text = proverka.CodeOplati.ToString();
                sum.Text = proverka.Summa.ToString();

            }

        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            if (vyborC.SelectedItem == null || string.IsNullOrEmpty(sum.Text) ||
                data.SelectedDate == null)
            {
                MessageBox.Show("Пустое(ые) поле(я)");
            }
            else 
            {
                decimal Price = Convert.ToDecimal(sum.Text);
                Oplati1 o = new Oplati1();
                var vybor = (Clients1)vyborC.SelectedItem;
                o.Client_ID = vybor.ID_Client;
                o.CodeOplati = int.Parse(code.Text);
                o.Summa = Price;
                o.DateOplati = data.SelectedDate.Value.ToString("yyyy-MM-dd");
                c.Oplati1Set.Add(o);
                c.SaveChanges();
                dg.ItemsSource = c.Oplati1Set.ToList();
                Clear();

            }
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (vyborC.SelectedItem == null || string.IsNullOrEmpty(sum.Text) ||
                    data.SelectedDate == null)
                {
                    MessageBox.Show("Пустое(ые) поле(я)");
                }
                else
                {
                    decimal Price = Convert.ToDecimal(sum.Text);
                    var o = dg.SelectedItem as Oplati1;
                    var vybor = (Clients1)vyborC.SelectedItem;
                    o.Client_ID = vybor.ID_Client;
                    o.CodeOplati = int.Parse(code.Text);
                    o.Summa = Price;
                    o.DateOplati = data.SelectedDate.Value.ToString("yyyy-MM-dd");
                    c.SaveChanges();
                    dg.ItemsSource = c.Oplati1Set.ToList();
                    Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void remove_click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private int GenerateUniqueCode()
        {
            Random random = new Random();
            int code = random.Next(1000, 9999); 

            while (c.Oplati1Set.Any(opl => opl.CodeOplati == code))
            {
                code = random.Next(1000, 9999);
            }

            return code;
        }

        private void UpdatePaymentData()
        {
            if (vyborC.SelectedValue != null)
            {
                int clientId = (int)vyborC.SelectedValue;
                var client = c.Clients1Set.FirstOrDefault(c => c.ID_Client == clientId);

                if (client != null)
                {
                    var abonement = c.Abonements1Set.FirstOrDefault(a => a.ID_Abonement == client.Abonement_ID);
                    if (abonement != null)
                    {
                        sum.Text = abonement.Cost.ToString("F2");
                    }
                    else
                    {
                        sum.Text = "0.00";
                    }
                }
            }
            else
            {
                sum.Text = "0.00";
            }
        }

        private void Clear()
        {
            data.SelectedDate = null;
            sum.Text = null;
            code.Text = null;
            vyborC.SelectedItem = null;
        }


        private void vyborC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePaymentData();
        }
    }
}
