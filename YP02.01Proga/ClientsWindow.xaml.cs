using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        private ProFormEntities c = new ProFormEntities();
        public ClientsWindow()
        {
            InitializeComponent();
            dg.ItemsSource = c.Clients1Set.ToList();
            vybor.ItemsSource = c.SrokiAbonements.ToList();
            vybor.DisplayMemberPath = "SrokAbonementa";
            vybor.SelectedValuePath = "ID_SrokAbonementa";
            data.SelectedDate = DateTime.Today;
            datakon.SelectedDate = DateTime.Today;
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindowAdmin adm = new MainWindowAdmin();
            adm.Show();
            this.Close();

        }

        private void phone_gotfocus(object sender, RoutedEventArgs e)
        {
            phone.Text = "+7";
            phone.CaretIndex = phone.Text.Length;
        }
        private void phone_input(object sender, TextCompositionEventArgs e)
        {
            var text = sender as TextBox;
            if (text.Text.Length >= 12)
            {
                e.Handled = true;
                return;
            }
            Regex regex = new Regex("^[0-9]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void phone_text(object sender, TextChangedEventArgs e)
        {
            if (!phone.Text.StartsWith("+7"))
            {
                phone.Text = "+7";
                phone.CaretIndex = phone.Text.Length;
            }
        }

        private void dg_select(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Clients1)dg.SelectedItem;
            if (proverka != null)
            {
                string dataa = data.SelectedDate.ToString();
                dataa = proverka.DatePokupki;
                string dataa2 = datakon.SelectedDate.ToString();
                dataa2 = proverka.DateOkonchaniya;
                name.Text = proverka.ClientName;
                surname.Text = proverka.ClientSurname;
                middlename.Text = proverka.ClientMiddlename;
                phone.Text = proverka.PhoneNumber;
                vybor.SelectedItem = proverka.Abonement_ID;
                
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_click(object sender, RoutedEventArgs e)
        {

        }

        private void remove_click(object sender, RoutedEventArgs e)
        {

        }
        private void Proverka(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[а-яА-ЯёЁ]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void Clear()
        {

        }

        private void vybor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vybor.SelectedItem is SrokiAbonements selectedSrok)
            {
                string selectedText = selectedSrok.SrokAbonementa;
                DateTime today = DateTime.Today;

                switch (selectedText.ToLower())
                {
                    case "месяц":
                        datakon.SelectedDate = today.AddMonths(1);
                        break;
                    case "полгода":
                        datakon.SelectedDate = today.AddMonths(6);
                        break;
                    case "год":
                        datakon.SelectedDate = today.AddYears(1);
                        break;
                    default:
                        datakon.SelectedDate = today;
                        break;
                }
            }
        }
    }
}
