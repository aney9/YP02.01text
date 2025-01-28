using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YP02._01Proga
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProFormEntities c = new ProFormEntities();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try {
                var vxod = c.Sotrudniki.ToList();
                bool avtoriz = false;

                if (string.IsNullOrWhiteSpace(login.Text) || string.IsNullOrWhiteSpace(pass.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return;
                }

                if (pass.Text.Length < 4)
                {
                    MessageBox.Show("Пароль должен быть больше 4 символов");
                }
                
                foreach (var v in vxod)
                {
                    if (v.Loginn == login.Text && v.Passwordd == pass.Text)
                    {
                        avtoriz = true;

                        if (v.RoleSotrudnik_ID == 2)
                        {
                            Otchet o = new Otchet();
                            o.Show();
                            this.Close();
                        }
                        else if (v.RoleSotrudnik_ID == 1) 
                        {
                            MainWindowAdmin adm = new MainWindowAdmin();
                            adm.Show();
                            this.Close();
                        }
                        else if (v.RoleSotrudnik_ID == 3)
                        {
                            TrenerMainWindow tr = new TrenerMainWindow();
                            tr.Show();
                            this.Close();
                        }

                        Close();
                        break;
                    }
                }

                if (!avtoriz)
                {
                    MessageBox.Show("Такого логина/пароля не существует. Попробуйте еще раз.");
                    login.Text = null;
                    pass.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
