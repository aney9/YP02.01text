using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Spire.Pdf.Graphics;
using Spire.Pdf;

namespace YP02._01Proga
{
    public partial class TrenerMainWindow : Window
    {
        public ObservableCollection<Zaniatiya1> ZaniatiyaList { get; set; }
        private ProFormEntities c = new ProFormEntities();
        public TrenerMainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadDataFromDatabase();
            BindDataToList();
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

        private void BindDataToList()
        {
            List.Items.Clear();

            foreach (var item in ZaniatiyaList)
            {
                UserView userView = new UserView();

                userView.DataContext = item;

                List.Items.Add(userView);
            }
        }

        private void otchet_click(object sender, RoutedEventArgs e)
        {
            TxtForm();
        }

        private void TxtForm()
        {
            string txtFilePath2 = System.IO.Path.Combine("output_2.txt");
            string pdfFilePath2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Расписание занятий.pdf");

            using (FileStream fs = new FileStream(txtFilePath2, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
            {
                string header = "Расписание занятий";
                int lineWidth = 70;

                string CenterString(string text, int width)
                {
                    if (text.Length >= width) return text;
                    int padding = (width - text.Length) / 2;
                    return new string(' ', padding) + text;
                }
                writer.WriteLine(CenterString(header, lineWidth));
                writer.WriteLine(new string('-', lineWidth));

                var ZaniatiyaData = c.Zaniatiya1Set
                    .Join(c.Treners1Set, z => z.Trener_ID, t => t.ID_Trener, (z, t) => new { z, t })
                    .Select(x => new
                    {
                        x.z.NameZaniatiya,
                        x.z.DateZaniatiya,
                        x.z.ColvoUchastnikov,
                        TrenerFullName = x.t.TrenerName + " " + x.t.TrenerSurname + " " + x.t.TrenerMiddleName // формируем полное имя тренера
                    })
                    .ToList();

                decimal totalParticipants = 0;
                foreach (var z in ZaniatiyaData)
                {
                    writer.WriteLine($"Занятие: {z.NameZaniatiya}");
                    writer.WriteLine($"Дата: {z.DateZaniatiya}");
                    writer.WriteLine($"Количество участников: {z.ColvoUchastnikov}");
                    writer.WriteLine($"Тренер: {z.TrenerFullName}"); // выводим полное имя тренера
                    writer.WriteLine(new string('-', lineWidth));
                    totalParticipants += z.ColvoUchastnikov;
                }

                writer.WriteLine($"{"Общее количество участников:",-10} {totalParticipants}");
            }

            ConvertTxtToPdf(txtFilePath2, pdfFilePath2);
            File.Delete(txtFilePath2);
        }

        public static void ConvertTxtToPdf(string txtFilePath, string pdfFilePath)
        {
            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    PdfPageBase page = document.Pages.Add();
                    Font fontt = new Font("Times New Roman", 12f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
                    PdfTrueTypeFont font = new PdfTrueTypeFont(fontt, 12f, true);
                    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top);
                    string[] lines = File.ReadAllLines(txtFilePath, Encoding.UTF8);

                    float y = 20;
                    float lineHeight = font.MeasureString("A").Height + 2;
                    float pageWidth = page.Canvas.ClientSize.Width;

                    string header = lines.First();
                    float headerWidth = font.MeasureString(header).Width;
                    float headerX = (pageWidth - headerWidth) / 2;
                    page.Canvas.DrawString(header, font, PdfBrushes.Black, new PointF(headerX, y), format);
                    y += lineHeight;

                    y += lineHeight;

                    foreach (string line in lines.Skip(1))
                    {
                        if (line.Trim() == "")
                            continue;

                        float lineWidth = font.MeasureString(line).Width;

                        page.Canvas.DrawString(line, font, PdfBrushes.Black, new PointF(20, y), format);
                        y += lineHeight;
                    }

                    document.SaveToFile(pdfFilePath);
                    MessageBox.Show($"PDF файл успешно создан на рабочем столе");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании PDF: {ex.Message}");
            }
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindow tr = new MainWindow();
            tr.Show();
            this.Close();
        }
    }
}
