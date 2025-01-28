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
    /// Логика взаимодействия для WindowTrener.xaml
    /// </summary>
    public partial class WindowTrener : Window
    {
        private ProFormEntities c = new ProFormEntities();
        public WindowTrener()
        {
            InitializeComponent();
            dg.ItemsSource = c.Treners1Set.ToList();
            vybor.ItemsSource = c.TrenerTypes1Set.ToList();
            vybor.DisplayMemberPath = "TrenerType";
            vybor.SelectedValuePath = "ID_TrenerTypes";
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


                if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(surname.Text) || string.IsNullOrEmpty(middlename.Text) ||
                    string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(password.Text) || vybor.SelectedItem == null)
                {
                    MessageBox.Show("Пустое(ые) поле(я)");
                    Clear();
                }
                else
                {
                    if (c.Treners1Set.Any(r => r.Email == email.Text))
                    {
                        MessageBox.Show("Тренер с такой почтой уже существует");
                        Clear();
                    }
                    else
                    {
                        if (!CheckEmail(email.Text))
                        {
                            MessageBox.Show("Неверно введена почта");
                            email.Text = null;
                        }
                        else
                        {
                            if (password.Text.Length < 4)
                            {
                                MessageBox.Show("Пароль должен быть больше 4-х символов");
                                password.Text = null;
                            }
                            else
                            {
                                Treners1 tr = new Treners1();
                                var vyborr = (TrenerTypes1)vybor.SelectedItem;
                                tr.TrenerTypes_ID = vyborr.ID_TrenerTypes;
                                tr.TrenerName = name.Text;
                                tr.TrenerSurname = surname.Text;
                                tr.TrenerMiddleName = middlename.Text;
                                tr.Email = email.Text;
                                tr.Passwordd = password.Text;
                                c.Treners1Set.Add(tr);
                                c.SaveChanges();
                                dg.ItemsSource = c.Treners1Set.ToList();
                                Clear();
                            }
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
                if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(surname.Text) || string.IsNullOrEmpty(middlename.Text) ||
                    string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(password.Text) || vybor.SelectedItem == null)
                {
                    MessageBox.Show("Пустое(ые) поле(я)");
                    Clear();
                }
                else
                {
                    if (!CheckEmail(email.Text))
                    {
                        MessageBox.Show("Неверно введена почта");
                        email.Text = null;
                    }
                    else
                    {
                        if (password.Text.Length < 4)
                        {
                            MessageBox.Show("Пароль должен быть больше 4-х символов");
                            password.Text = null;
                        }
                        else
                        {
                            var tr = dg.SelectedItem as Treners1;
                            var vyborr = (TrenerTypes1)vybor.SelectedItem;
                            tr.TrenerTypes_ID = vyborr.ID_TrenerTypes;
                            tr.TrenerName = name.Text;
                            tr.TrenerSurname = surname.Text;
                            tr.TrenerMiddleName = middlename.Text;
                            tr.Email = email.Text;
                            tr.Passwordd = password.Text;
                            c.SaveChanges();
                            dg.ItemsSource = c.Treners1Set.ToList();
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

        private void delete_click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (dg.SelectedItem != null)
                {
                    var selectedItem = dg.SelectedItem as Treners1;
                    var proverka = c.Zaniatiya1Set.Any(o => o.Trener_ID == selectedItem.ID_Trener);
                    if (proverka)
                    {
                        MessageBox.Show("Невозможно удалить, так как данные используются в другой таблице");
                        Clear();
                    }
                    else
                    {
                        c.Treners1Set.Remove(selectedItem);
                        c.SaveChanges();
                        dg.ItemsSource = c.Treners1Set.ToList();
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

        private void dg_select(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Treners1)dg.SelectedItem;
            if (proverka != null) 
            {
                vybor.SelectedValue = proverka.TrenerTypes_ID;
                name.Text = proverka.TrenerName;
                surname.Text = proverka.TrenerSurname;
                middlename.Text = proverka.TrenerMiddleName;
                email.Text = proverka.Email;
                password.Text = proverka.Passwordd;
            }
        }
        private void Proverka(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[а-яА-ЯёЁ]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private bool CheckEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void Clear()
        {
            name.Text = null;
            surname.Text = null;
            middlename.Text= null;
            email.Text = null;
            password.Text = null;
            vybor.SelectedValue = null;
        }


    }
}
