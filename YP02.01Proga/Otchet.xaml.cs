using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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



using SixLabors.Fonts;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Font = System.Drawing.Font;

namespace YP02._01Proga
{
    /// <summary>
    /// Логика взаимодействия для Otchet.xaml
    /// </summary>
    public partial class Otchet : Window
    {
        private ProFormEntities c = new ProFormEntities();
        public Otchet()
        {
            InitializeComponent();
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void otchet_click(object sender, RoutedEventArgs e)
        {
            TxtForm();
        }

        private void TxtForm()
        {
            string txtFilePath2 = System.IO.Path.Combine("output_1.txt");
            string pdfFilePath2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Общая загрузка абонементов.pdf");
            using (FileStream fs = new FileStream(txtFilePath2, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
            {
                string header = "Общая загрузка Абонементов";
                int lineWidth = 70;

                string CenterString(string text, int width)
                {
                    if (text.Length >= width) return text;
                    int padding = (width - text.Length) / 2;
                    return new string(' ', padding) + text;
                }
                writer.WriteLine(CenterString(header, lineWidth));
                writer.WriteLine(new string('-', lineWidth));

                // Выборка данных из таблиц
                var OrdersData = c.Clients1Set
                    .Join(c.Abonements1Set, c => c.Abonement_ID, a => a.ID_Abonement, (c, a) => new { c, a })
                    .Join(c.Oplati1Set, ca => ca.c.ID_Client, o => o.Client_ID, (ca, o) => new
                    {
                        ca.a.Cost,
                        ca.a.ColvoPosesheniy,
                        o.Summa
                    })
                    .GroupBy(x => new { x.Cost, x.ColvoPosesheniy })
                    .ToList();

                decimal totalRevenue = 0;
                foreach (var order in OrdersData)
                {
                    decimal revenueForAbonement = order.Sum(x => x.Summa);
                    writer.WriteLine($"Абонемент (стоимость): {order.Key.Cost} руб.");
                    writer.WriteLine($"Количество посещений: {order.Key.ColvoPosesheniy}");
                    writer.WriteLine($"Выручка за абонемент: {revenueForAbonement} руб.");
                    writer.WriteLine(new string('-', lineWidth));
                    totalRevenue += revenueForAbonement;
                }

                writer.WriteLine($"{"Общая выручка:",-10} {totalRevenue} руб.");
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

    }
}
