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
    /// Логика взаимодействия для WindowAbonements.xaml
    /// </summary>
    public partial class WindowAbonements : Window
    {
        private ProFormEntities c = new ProFormEntities();
        public WindowAbonements()
        {
            InitializeComponent();
            dg.ItemsSource = c.Abonements1Set.ToList();
            vyborSpec.ItemsSource = c.TypeDeystviyas1Set.ToList();
            vyborSpec.DisplayMemberPath = "TypeDeystviya";
            vyborSpec.SelectedValuePath = "ID_TypeDeystviya";
            vyborSrok.ItemsSource = c.SrokiAbonements.ToList();
            vyborSrok.DisplayMemberPath = "SrokAbonementa";
            vyborSrok.SelectedValuePath = "ID_SrokAbonementa";


        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindowAdmin adm = new MainWindowAdmin();
            adm.Show();
            this.Close();
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Stoimost.Text) || string.IsNullOrEmpty(Kolvo.Text) || vyborSrok.SelectedItem == null || vyborSpec.SelectedItem == null)
            {
                MessageBox.Show("Пустое(ые) поле(я)");
            }
            else
            {
                decimal Price = Convert.ToDecimal(Stoimost.Text);
                if (Price == 0)
                {
                    MessageBox.Show("Цена должна быть больше 0");
                }
                else
                {
                    int kolvo = Convert.ToInt32(Kolvo.Text);
                    if (kolvo == 0)
                    {
                        MessageBox.Show("Количество посещений должно быть больше 0");
                    }
                    else
                    {
                            Abonements1 ab = new Abonements1();
                            var vybor = (SrokiAbonements)vyborSrok.SelectedItem;
                            var vybor1 = (TypeDeystviyas1)vyborSpec.SelectedItem;
                            ab.SrokAbonementa_ID = vybor.ID_SrokAbonementa;
                            ab.TypeDeystviya_ID = vybor1.ID_TypeDeystviya;
                            ab.ColvoPosesheniy = kolvo;
                            ab.Cost = Price;
                            c.Abonements1Set.Add(ab);
                            c.SaveChanges();
                            dg.ItemsSource = c.Abonements1Set.ToList();
                            Clear();

                    }
                }
            }
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Stoimost.Text) || string.IsNullOrEmpty(Kolvo.Text) || vyborSrok.SelectedItem == null || vyborSpec.SelectedItem == null)
            {
                MessageBox.Show("Пустое(ые) поле(я)");
            }
            else
            {
                decimal Price = Convert.ToDecimal(Stoimost.Text);
                if (Price == 0)
                {
                    MessageBox.Show("Цена должна быть больше 0");
                }
                else
                {
                    int kolvo = Convert.ToInt32(Kolvo.Text);
                    if (kolvo == 0)
                    {
                        MessageBox.Show("Количество посещений должно быть больше 0");
                    }
                    else
                    {
                        var ab = dg.SelectedItem as Abonements1;
                        var vybor = (SrokiAbonements)vyborSrok.SelectedItem;
                        var vybor1 = (TypeDeystviyas1)vyborSpec.SelectedItem;
                        ab.SrokAbonementa_ID = vybor.ID_SrokAbonementa;
                        ab.TypeDeystviya_ID = vybor1.ID_TypeDeystviya;
                        ab.ColvoPosesheniy = kolvo;
                        ab.Cost = Price;
                        c.SaveChanges();
                        dg.ItemsSource = c.Abonements1Set.ToList();
                        Clear();
                    }
                }
            }
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                var selectedItem = dg.SelectedItem as Abonements1;
                var proverka = c.Clients1Set.Any(o => o.Abonement_ID == selectedItem.ID_Abonement);
                if (proverka)
                {
                    MessageBox.Show("Невозможно удалить, так как данные используются в другой таблице");
                    Clear();
                }
                else
                {
                    c.Abonements1Set.Remove(selectedItem);
                    c.SaveChanges();
                    dg.ItemsSource = c.Abonements1Set.ToList();
                    Clear();
                }
            }

        }

        private void remove_click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void dg_select(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Abonements1)dg.SelectedItem;
            if (proverka != null)
            {

                vyborSpec.SelectedValue = proverka.TypeDeystviya_ID;
                vyborSrok.SelectedValue = proverka.SrokAbonementa_ID;
                Stoimost.Text = proverka.Cost.ToString();
                Kolvo.Text = proverka.ColvoPosesheniy.ToString();
            }
        }

        private void proverka_input(object sender, TextCompositionEventArgs e)
        {
            var text = sender as TextBox;

            Regex regex = new Regex("^[0-9,]+$");
            bool isMatch = regex.IsMatch(e.Text);

            if (isMatch && text.Text.Contains(",") && e.Text == ",")
            {
                e.Handled = true;
                return;
            }

            e.Handled = !isMatch;
        }

        private void proverka_text(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                string value = textBox.Text;

                if (!Regex.IsMatch(value, @"^\d*(,\d{0,2})?$")) 
                {
                    textBox.Text = value.Substring(0, value.Length - 1);
                    textBox.CaretIndex = textBox.Text.Length;
                }
            }
        }


        private void proverkaa_input(object sender, TextCompositionEventArgs e)
        {
            var text = sender as TextBox;
            Regex regex = new Regex("^[0-9]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void proverkaa_text(object sender, TextChangedEventArgs e)
        {
            var text = sender as TextBox;
            if (!string.IsNullOrEmpty(Kolvo.Text) && !Regex.IsMatch(text.Text, @"^\d+$"))
                {
                text.Text = string.Empty;
            }
        }

        private void Clear()
        {
            vyborSpec.ItemsSource = null;
            vyborSrok.ItemsSource = null;
            Stoimost.Text = null;
            Kolvo.Text = null;
        }


    }
}
