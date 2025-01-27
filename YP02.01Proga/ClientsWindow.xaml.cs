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
            vybor.ItemsSource = c.Abonements1Set.ToList();
            vybor.DisplayMemberPath = "ColvoPosesheniy";
            vybor.SelectedValuePath = "ID_Abonement";
            data.SelectedDate = DateTime.Today;
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
                data.SelectedDate = DateTime.Parse(proverka.DatePokupki);
                datakon.SelectedDate = DateTime.Parse(proverka.DateOkonchaniya);
                name.Text = proverka.ClientName;
                surname.Text = proverka.ClientSurname;
                middlename.Text = proverka.ClientMiddlename;
                phone.Text = proverka.PhoneNumber;
                vybor.SelectedValue = proverka.Abonement_ID;
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data.SelectedDate == null || datakon.SelectedDate == null || (string.IsNullOrEmpty(name.Text) ||
                    (string.IsNullOrEmpty(surname.Text) || (string.IsNullOrEmpty(middlename.Text) ||
                    (string.IsNullOrEmpty(phone.Text) || vybor.SelectedItem == null)))))
                {
                    MessageBox.Show("Пустое(ые) поле(я)");
                }
                else
                {
                    if (c.Clients1Set.Any(r => r.PhoneNumber == phone.Text))
                    {
                        MessageBox.Show("Клиент с таким номером телефона уже существует");
                        phone.Text = null;
                    }
                    else
                    {
                        if (phone.Text.Length < 12)
                        {
                            MessageBox.Show("Номер телефона должен состоять из 12 символов");
                        }
                        else
                        {
                            Clients1 cl = new Clients1();
                            var vyborr = (Abonements1)vybor.SelectedItem;
                            cl.Abonement_ID = vyborr.ID_Abonement;
                            cl.ClientName = name.Text;
                            cl.ClientSurname = surname.Text;
                            cl.ClientMiddlename = middlename.Text;
                            cl.PhoneNumber = phone.Text;
                            cl.DatePokupki = data.SelectedDate.Value.ToString("yyyy-MM-dd");
                            cl.DateOkonchaniya = datakon.SelectedDate.Value.ToString("yyyy-MM-dd");
                            c.Clients1Set.Add(cl);
                            c.SaveChanges();
                            dg.ItemsSource = c.Clients1Set.ToList();
                            Clear();
                        }
                    }
                }    
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data.SelectedDate == null || datakon.SelectedDate == null || (string.IsNullOrEmpty(name.Text) ||
                    (string.IsNullOrEmpty(surname.Text) || (string.IsNullOrEmpty(middlename.Text) ||
                    (string.IsNullOrEmpty(phone.Text) || vybor.SelectedItem == null)))))
                {
                    MessageBox.Show("Пустое(ые) поле(я)");
                }
                else
                {
                    if (phone.Text.Length < 12)
                    {
                        MessageBox.Show("Номер телефона должен состоять из 12 символов");
                    }
                    else
                    {
                        var cl = dg.SelectedItem as Clients1;
                        var vyborr = (Abonements1)vybor.SelectedItem;
                        cl.Abonement_ID = vyborr.ID_Abonement;
                        cl.ClientName = name.Text;
                        cl.ClientSurname = surname.Text;
                        cl.ClientMiddlename = middlename.Text;
                        cl.PhoneNumber = phone.Text;
                        cl.DatePokupki = data.SelectedDate.Value.ToString("yyyy-MM-dd");
                        cl.DateOkonchaniya = datakon.SelectedDate.Value.ToString("yyyy-MM-dd");
                        c.SaveChanges();
                        dg.ItemsSource = c.Clients1Set.ToList();
                        Clear();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (dg.SelectedItem != null)
                {
                    var selectedItem = dg.SelectedItem as Clients1;
                    var proverka = c.ZaniatiyaClients1Set.Any(o => o.Client_ID == selectedItem.ID_Client);
                    var proverkaa = c.Oplati1Set.Any(o => o.Client_ID == selectedItem.ID_Client);
                    if (proverka || proverkaa)
                    {
                        MessageBox.Show("Невозможно удалить, так как данные используются в другой таблице");
                        Clear();
                    }
                    else
                    {
                        c.Clients1Set.Remove(selectedItem);
                        c.SaveChanges();
                        dg.ItemsSource = c.Clients1Set.ToList();
                        Clear();
                    }
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
        private void Proverka(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[а-яА-ЯёЁ]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void Clear()
        {
            data.SelectedDate = null;
            datakon.SelectedDate = null;
            name.Text = null;
            surname.Text = null;
            middlename.Text = null;
            phone.Text = null;
            vybor.SelectedItem = null;
        }

        ////private void vybor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (vybor.SelectedItem is SrokiAbonements selectedSrok)
        //    {
        //        string selectedText = selectedSrok.SrokAbonementa;
        //        DateTime today = DateTime.Today;

        //        switch (selectedText.ToLower())
        //        {
        //            case "месяц":
        //                datakon.SelectedDate = today.AddMonths(1);
        //                break;
        //            case "полгода":
        //                datakon.SelectedDate = today.AddMonths(6);
        //                break;
        //            case "год":
        //                datakon.SelectedDate = today.AddYears(1);
        //                break;
        //            default:
        //                datakon.SelectedDate = today;
        //                break;
        //        }
        //    }
        //}
    }
}
