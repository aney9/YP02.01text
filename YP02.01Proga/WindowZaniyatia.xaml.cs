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
    /// Логика взаимодействия для WindowZaniyatia.xaml
    /// </summary>
    public partial class WindowZaniyatia : Window
    {
        private ProFormEntities c = new ProFormEntities();
        public WindowZaniyatia()
        {
            InitializeComponent();
            dg.ItemsSource = c.Zaniatiya1Set.ToList();
            vybor.ItemsSource = c.Treners1Set.ToList();
            vybor.DisplayMemberPath = "Email";
            vybor.SelectedValuePath = "ID_Trener";
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindowAdmin adm = new MainWindowAdmin();
            adm.Show();
            this.Close();
        }

        private void dg_select(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Zaniatiya1)dg.SelectedItem;
            if (proverka != null )
            {
                data.SelectedDate = DateTime.Parse(proverka.DateZaniatiya);
                name.Text = proverka.NameZaniatiya;
                chas.Text = proverka.ColvoHours.ToString();
                uchast.Text = proverka.ColvoUchastnikov.ToString();
                vybor.SelectedValue = proverka.Trener_ID;
            }
        }
        private void Proverka(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[а-яА-ЯёЁ]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(name.Text) || data.SelectedDate == null || string.IsNullOrEmpty(uchast.Text) ||
                string.IsNullOrEmpty(chas.Text) || vybor.SelectedItem == null)
                {
                    MessageBox.Show("Пустое(ые) поле(я)");
                    Clear();
                }
                else
                {
                    Zaniatiya1 z = new Zaniatiya1();
                    var vyborr = (Treners1)vybor.SelectedItem;
                    z.Trener_ID = vyborr.ID_Trener;
                    z.NameZaniatiya = name.Text;
                    z.ColvoHours = int.Parse(chas.Text);
                    z.ColvoUchastnikov = int.Parse(uchast.Text);
                    z.DateZaniatiya = data.SelectedDate.Value.ToString("yyyy-MM-dd");
                    c.Zaniatiya1Set.Add(z);
                    c.SaveChanges();
                    dg.ItemsSource = c.Zaniatiya1Set.ToList();
                    Clear();
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
                if (string.IsNullOrEmpty(name.Text) || data.SelectedDate == null || string.IsNullOrEmpty(uchast.Text) ||
                string.IsNullOrEmpty(chas.Text) || vybor.SelectedItem == null)
                {
                    MessageBox.Show("Пустое(ые) поле(я)");
                    Clear();
                }
                else
                {
                    var z = dg.SelectedItem as Zaniatiya1;
                    var vyborr = (Treners1)vybor.SelectedItem;
                    z.Trener_ID = vyborr.ID_Trener;
                    z.NameZaniatiya = name.Text;
                    z.ColvoHours = int.Parse(chas.Text);
                    z.ColvoUchastnikov = int.Parse(uchast.Text);
                    z.DateZaniatiya = data.SelectedDate.Value.ToString("yyyy-MM-dd");
                    c.SaveChanges();
                    dg.ItemsSource = c.Zaniatiya1Set.ToList();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                var selectedItem = dg.SelectedItem as Zaniatiya1;
                var proverka = c.ZaniatiyaClients1Set.Any(o => o.Zaniatiya_ID == selectedItem.ID_Zaniatiya);
                if (proverka)
                {
                    MessageBox.Show("Невозможно удалить, так как данные используются в другой таблице");
                    Clear();
                }
                else
                {
                    c.Zaniatiya1Set.Remove(selectedItem);
                    c.SaveChanges();
                    dg.ItemsSource = c.Zaniatiya1Set.ToList();
                    Clear();
                }
            }
        }

        private void remove_click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            data.SelectedDate = null;
            name.Text = null;
            chas.Text = null;
            uchast = null;
            vybor.SelectedItem = null;
        }
    }
}
