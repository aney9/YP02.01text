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
    /// Логика взаимодействия для WindowOblastDeistviya.xaml
    /// </summary>
    public partial class WindowOblastDeistviya : Window
    {
        private ProFormEntities c = new ProFormEntities();
        public WindowOblastDeistviya()
        {
            InitializeComponent();
            dg.ItemsSource = c.TypeDeystviyas1Set.ToList();
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindowAdmin adm = new MainWindowAdmin();
            adm.Show();
            this.Close();
        }

        private void dg_select(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (TypeDeystviyas1)dg.SelectedItem;
            if (proverka != null)
            {
                type.Text = proverka.TypeDeystviya;
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(type.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (c.TypeDeystviyas1Set.Any(r => r.TypeDeystviya == type.Text))
                {
                    MessageBox.Show("Такой тип действия уже существует");
                    type.Text = null;
                }
                else
                {
                    TypeDeystviyas1 typee = new TypeDeystviyas1();
                    typee.TypeDeystviya = type.Text;
                    c.TypeDeystviyas1Set.Add(typee);
                    c.SaveChanges();
                    dg.ItemsSource = c.TypeDeystviyas1Set.ToList();
                    type.Text = null;
                }
            }
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(type.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (c.TypeDeystviyas1Set.Any(r => r.TypeDeystviya == type.Text))
                {
                    MessageBox.Show("Такой срок абонемента уже существует");
                    type.Text = null;
                }
                else
                {
                    var selectedItem = dg.SelectedItem as TypeDeystviyas1;
                    if (selectedItem != null)
                    {
                        selectedItem.TypeDeystviya = type.Text;
                        c.SaveChanges();
                        dg.ItemsSource = c.TypeDeystviyas1Set.ToList();
                        type.Text = null;
                    }
                }
            }
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                var selectedItem = dg.SelectedItem as TypeDeystviyas1;
                var proverka = c.Abonements1Set.Any(o => o.SrokAbonementa_ID == selectedItem.ID_TypeDeystviya);
                if (proverka)
                {
                    MessageBox.Show("Невозможно удалить, так как данные используются в другой таблице");
                    type.Text = null;
                }
                else
                {
                    c.TypeDeystviyas1Set.Remove(dg.SelectedItem as TypeDeystviyas1);
                    c.SaveChanges();
                    dg.ItemsSource = c.TypeDeystviyas1Set.ToList();
                    type.Text = null;
                }
            }
        }

        private void remove_click(object sender, RoutedEventArgs e)
        {
            type.Text = null;
        }

        private void Proverka(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[а-яА-ЯёЁ]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
