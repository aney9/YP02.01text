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
    /// Логика взаимодействия для WindowTypeTrener.xaml
    /// </summary>
    public partial class WindowTypeTrener : Window
    {
        private ProFormEntities c = new ProFormEntities();
        public WindowTypeTrener()
        {
            InitializeComponent();
            dg.ItemsSource = c.TrenerTypes1Set.ToList();
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindowAdmin adm = new MainWindowAdmin();
            adm.Show();
            this.Close();
        }

        private void dg_select(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (TrenerTypes1)dg.SelectedItem;
            if (proverka != null)
            {
                Type.Text = proverka.TrenerType;
            }
        }
        private void Proverka(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[а-яА-ЯёЁ]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Type.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (c.TrenerTypes1Set.Any(r => r.TrenerType == Type.Text))
                {
                    MessageBox.Show("Такой срок абонемента уже существует");
                    Type.Text = null;
                }
                else
                {
                    TrenerTypes1 tr = new TrenerTypes1();
                    tr.TrenerType = Type.Text;
                    c.TrenerTypes1Set.Add(tr);
                    c.SaveChanges();
                    dg.ItemsSource = c.TrenerTypes1Set.ToList();
                    Type.Text = null;
                }
            }
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Type.Text))
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                if (c.TrenerTypes1Set.Any(r => r.TrenerType == Type.Text))
                {
                    MessageBox.Show("Такой тип тренера уже существует");
                    Type.Text = null;
                }
                else
                {
                    var selectedItem = dg.SelectedItem as TrenerTypes1;
                    if (selectedItem != null)
                    {
                        selectedItem.TrenerType = Type.Text;
                        c.SaveChanges();
                        dg.ItemsSource = c.TrenerTypes1Set.ToList();
                        Type.Text = null;
                    }
                }
            }
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                var selectedItem = dg.SelectedItem as TrenerTypes1;
                var proverka = c.Abonements1Set.Any(o => o.TypeDeystviya_ID == selectedItem.ID_TrenerTypes);
                if (proverka)
                {
                    MessageBox.Show("Невозможно удалить, так как данные используются в другой таблице");
                    Type.Text = null;
                }
                else
                {
                    c.TrenerTypes1Set.Remove(dg.SelectedItem as TrenerTypes1);
                    c.SaveChanges();
                    dg.ItemsSource = c.TrenerTypes1Set.ToList();
                    Type.Text = null;
                }
            }
        }

        private void remove_click(object sender, RoutedEventArgs e)
        {
            Type.Text = null;
        }
    }
}
