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
    /// Логика взаимодействия для WindowSrokiAbonements.xaml
    /// </summary>
    public partial class WindowSrokiAbonements : Window
    {
        private ProFormEntities c = new ProFormEntities();
        public WindowSrokiAbonements()
        {
            InitializeComponent();
            dg.ItemsSource = c.SrokiAbonements.ToList();
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindowAdmin adm = new MainWindowAdmin();
            adm.Show();
            this.Close();
        }

        private void dg_select(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (SrokiAbonements)dg.SelectedItem;
            if (proverka != null)
            {
                Srok.Text = proverka.SrokAbonementa;
            }

        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Srok.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (c.SrokiAbonements.Any(r => r.SrokAbonementa == Srok.Text))
                {
                    MessageBox.Show("Такой срок абонемента уже существует");
                    Srok.Text = null;
                }
                else
                {
                    SrokiAbonements srok = new SrokiAbonements();
                    srok.SrokAbonementa = Srok.Text;
                    c.SrokiAbonements.Add(srok);
                    c.SaveChanges();
                    dg.ItemsSource = c.SrokiAbonements.ToList();
                    Srok.Text = null;
                }
            }

        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Srok.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (c.SrokiAbonements.Any(r => r.SrokAbonementa == Srok.Text))
                {
                    MessageBox.Show("Такой срок абонемента уже существует");
                    Srok.Text = null;
                }
                else
                {
                    var selectedItem = dg.SelectedItem as SrokiAbonements;
                    if (selectedItem != null)
                    {
                        selectedItem.SrokAbonementa = Srok.Text;
                        c.SaveChanges();
                        dg.ItemsSource = c.SrokiAbonements.ToList();
                        Srok.Text = null;
                    }
                }
            }
        }

        private void remove_click(object sender, RoutedEventArgs e)
        {
            Srok.Text = null;
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                var selectedItem = dg.SelectedItem as SrokiAbonements;
                var proverka = c.Abonements1Set.Any(o => o.SrokAbonementa_ID == selectedItem.ID_SrokAbonementa);
                if (proverka)
                {
                    MessageBox.Show("Невозможно удалить, так как данные используются в другой таблице");
                    Srok.Text = null;
                }
                else
                {
                    c.SrokiAbonements.Remove(dg.SelectedItem as SrokiAbonements);
                    c.SaveChanges();
                    dg.ItemsSource = c.SrokiAbonements.ToList();
                    Srok.Text = null;
                }
            }
        }

        //крч это проверка на ввод только русских букв в поле, она привязана к текстбоксику
      private void Proverka(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[а-яА-ЯёЁ]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
