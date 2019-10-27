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

namespace ExportGeoData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string excelFilePath = @"C:\For Waleed\For Work\Waleed, Fatih, and Fatih\il_ilce_semt_mahalle_koy.xlsx";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartExport(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);
                Microsoft.Office.Interop.Excel.Worksheet ilWorkSheet, ilçeWorkSheet;

                var wksht1 = workbook.Worksheets[0]; var wksht2 = workbook.Worksheets[1]; var wksht3 = workbook.Worksheets[2];


                excelApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
