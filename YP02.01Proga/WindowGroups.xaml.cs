using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using MaterialDesignThemes.Wpf.Converters;

namespace YP02._01Proga
{
    /// <summary>
    /// Логика взаимодействия для WindowGroups.xaml
    /// </summary>
    public partial class WindowGroups : Window
    {
        private ProFormEntities c = new ProFormEntities();
        public WindowGroups()
        {
            InitializeComponent();
            dg.ItemsSource = c.ZaniatiyaClients1Set.ToList();
            vyborZ.ItemsSource = c.Zaniatiya1Set.ToList();
            vyborZ.DisplayMemberPath = "NameZaniatiya";
            vyborZ.SelectedValuePath = "ID_Zaniatiya";
            vyborC.ItemsSource = c.Clients1Set.ToList();
            vyborC.DisplayMemberPath = "ClientSurname";
            vyborC.SelectedValuePath = "ID_Client";
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindowAdmin adm = new MainWindowAdmin();
            adm.Show();
            this.Close();
        }


        private void add_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (vyborZ.SelectedValue == null || vyborC.SelectedValue == null)
                {
                    MessageBox.Show("Пустое(ые) поле(я)");
                    Clear();
                }
                else
                {
                    ZaniatiyaClients1 z = new ZaniatiyaClients1();
                    var vybor = (Zaniatiya1)vyborZ.SelectedItem;
                    var vybor1 = (Clients1)vyborC.SelectedItem;
                    z.Zaniatiya_ID = vybor.ID_Zaniatiya;
                    z.Client_ID = vybor1.ID_Client;
                    c.ZaniatiyaClients1Set.Add(z);
                    c.SaveChanges();
                    dg.ItemsSource = c.ZaniatiyaClients1Set.ToList();
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
                if (vyborZ.SelectedValue == null || vyborC.SelectedValue == null)
                {
                    MessageBox.Show("Пустое(ые) поле(я)");
                    Clear();
                }
                else
                {
                    var z = dg.SelectedItem as ZaniatiyaClients1;
                    var vybor = (Zaniatiya1)vyborZ.SelectedItem;
                    var vybor1 = (Clients1)vyborC.SelectedItem;
                    z.Zaniatiya_ID = vybor.ID_Zaniatiya;
                    z.Client_ID = vybor1.ID_Client;
                    c.SaveChanges();
                    dg.ItemsSource = c.ZaniatiyaClients1Set.ToList();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при редактировании: {ex.Message}");
            }
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = dg.SelectedItem as ZaniatiyaClients1;

                c.ZaniatiyaClients1Set.Remove(selectedItem);
                c.SaveChanges();
                dg.ItemsSource = c.ZaniatiyaClients1Set.ToList();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при удалении: {ex.Message}");
            }
        }

        private void remove_click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void dg_select(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (ZaniatiyaClients1)dg.SelectedItem;
            if (proverka != null)
            {

                vyborZ.SelectedValue = proverka.Zaniatiya_ID;
                vyborC.SelectedValue = proverka.Client_ID;
            }
        }


        private void Clear()
        {
            vyborC.SelectedItem = null;
            vyborZ.SelectedItem = null;
        }

    }
}
