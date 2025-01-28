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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowAuthorizCl tr = new WindowAuthorizCl();
            tr.Show();
            this.Close();   
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowAuthorization r = new WindowAuthorization();
            r.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
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
    }
}
