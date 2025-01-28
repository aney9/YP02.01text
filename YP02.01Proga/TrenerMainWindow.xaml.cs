using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace YP02._01Proga
{
    /// <summary>
    /// Логика взаимодействия для TrenerMainWindow.xaml
    /// </summary>
    public partial class TrenerMainWindow : Window
    {
        public ObservableCollection<Zaniatiya1> ZaniatiyaList { get; set; }
        public TrenerMainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadDataFromDatabase();
            List.ItemsSource = ZaniatiyaList;
        }
        private void LoadDataFromDatabase()
        {
            using (var context = new ProFormEntities())
            {
                try
                {
                    var dataFromDb = context.Zaniatiya1Set.ToList();

                    if (dataFromDb.Count == 0)
                    {
                        MessageBox.Show("Данные не найдены в базе данных.");
                    }
                    else
                    {
                        ZaniatiyaList = new ObservableCollection<Zaniatiya1>(dataFromDb);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при извлечении данных: {ex.Message}");
                }
            }

        }

    }
}
