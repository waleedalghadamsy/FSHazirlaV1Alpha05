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

namespace WpfExcelGeoDataImporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Microsoft.Office.Interop.Excel.Application excelApp;
        Microsoft.Office.Interop.Excel.Workbook workbook;
        private string excelFilePath = @"C:\For Waleed\For Work\Waleed, Fatih, and Fatih\il_ilce_semt_mahalle_koy.xlsx",
            connStr = "Data Source=.\\sqlexpr16; Initial Catalog=BisiparişVT; Persist Security Info=True; "
                    + "user id=waleed; password=AbcXyz123;",
            cmd1Str = "INSERT INTO İller(AktifMi, Oluşturulduğunda, OluşturuKimsiId, Ad, Plaka) " +
            "VALUES(@AktifMi, @Oluşturulduğunda, @OluşturuKimsiId, @Ad, @Plaka)",
            cmd2Str = "INSERT INTO İlçeler(AktifMi, Oluşturulduğunda, OluşturuKimsiId, Ad, İlId) " +
            "VALUES(@AktifMi, @Oluşturulduğunda, @OluşturuKimsiId, @Ad, @İlId)",
            cmd3Str = "INSERT INTO Semtler(AktifMi, Oluşturulduğunda, OluşturuKimsiId, Ad, PostaKodu, İlçeId) " +
            "VALUES(@AktifMi, @Oluşturulduğunda, @OluşturuKimsiId, @Ad, @PostaKodu, @İlçeId)",
            cmd4Str = "INSERT INTO Mahalleler(AktifMi, Oluşturulduğunda, OluşturuKimsiId, Ad, SemtId) " +
            "VALUES(@AktifMi, @Oluşturulduğunda, @OluşturuKimsiId, @Ad, @SemtId)";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            excelApp = new Microsoft.Office.Interop.Excel.Application();
            workbook = excelApp.Workbooks.Open(excelFilePath);
        }

        private void Importİller(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Worksheet worksheet1;
                System.Data.SqlClient.SqlConnection conn;
                System.Data.SqlClient.SqlCommand cmd;

                using (conn = new System.Data.SqlClient.SqlConnection(connStr))
                using (cmd = new System.Data.SqlClient.SqlCommand(cmd1Str, conn))
                {
                    cmd.Parameters.Add("@AktifMi", System.Data.SqlDbType.Bit, 1, "AktifMi");
                    cmd.Parameters.Add("@Oluşturulduğunda", System.Data.SqlDbType.DateTime2, 7, "Oluşturulduğunda");
                    cmd.Parameters.Add("@OluşturuKimsiId", System.Data.SqlDbType.Int, 4, "OluşturuKimsiId");
                    cmd.Parameters.Add("@Ad", System.Data.SqlDbType.NVarChar, 20, "Ad");
                    cmd.Parameters.Add("@Plaka", System.Data.SqlDbType.TinyInt, 1, "Plaka");

                    worksheet1 = workbook.Worksheets[1];
                    var row = 2; var rowStr = ""; var ilAd = "";

                    cmd.Parameters["@AktifMi"].Value = 1;
                    cmd.Parameters["@Oluşturulduğunda"].Value = DateTime.Now;
                    cmd.Parameters["@OluşturuKimsiId"].Value = 1;

                    conn.Open();

                    do
                    {
                        rowStr = row.ToString();
                        ilAd = worksheet1.Range["D" + rowStr].Text;

                        if (!string.IsNullOrWhiteSpace(ilAd))
                        {
                            cmd.Parameters["@Ad"].Value = ilAd; cmd.Parameters["@Plaka"].Value = row - 1;

                            cmd.ExecuteNonQuery();

                            row++;
                        }
                    } while (!string.IsNullOrWhiteSpace(ilAd));

                    conn.Close();

                    MessageBox.Show("İller Done");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Importİlçeler(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Worksheet worksheet2;
            System.Data.SqlClient.SqlConnection conn;
            System.Data.SqlClient.SqlCommand cmd;

            try
            {
                using (conn = new System.Data.SqlClient.SqlConnection(connStr))
                using (cmd = new System.Data.SqlClient.SqlCommand(cmd2Str, conn))
                {
                    cmd.Parameters.Add("@AktifMi", System.Data.SqlDbType.Bit, 1, "AktifMi");
                    cmd.Parameters.Add("@Oluşturulduğunda", System.Data.SqlDbType.DateTime2, 7, "Oluşturulduğunda");
                    cmd.Parameters.Add("@OluşturuKimsiId", System.Data.SqlDbType.Int, 4, "OluşturuKimsiId");
                    cmd.Parameters.Add("@Ad", System.Data.SqlDbType.NVarChar, 20, "Ad");
                    cmd.Parameters.Add("@İlId", System.Data.SqlDbType.Int, 4, "İlId");

                    worksheet2 = workbook.Worksheets[2];
                    var row = 2; var rowStr = ""; var ilçeAd = ""; var ilId = "";

                    cmd.Parameters["@AktifMi"].Value = 1;
                    cmd.Parameters["@Oluşturulduğunda"].Value = DateTime.Now;
                    cmd.Parameters["@OluşturuKimsiId"].Value = 1;

                    conn.Open();
                    row = 2;

                    do
                    {
                        rowStr = row.ToString();
                        ilId = worksheet2.Range["B" + rowStr].Text; ilçeAd = worksheet2.Range["D" + rowStr].Text;

                        if (!string.IsNullOrWhiteSpace(ilçeAd))
                        {
                            cmd.Parameters["@Ad"].Value = ilçeAd; cmd.Parameters["@İlId"].Value = int.Parse(ilId);

                            row++;

                            cmd.ExecuteNonQuery();
                        }
                    } while (!string.IsNullOrWhiteSpace(ilçeAd));

                    conn.Close();

                    MessageBox.Show("İlçeler Done");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void ImportSemtler(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Worksheet worksheet1;
                System.Data.SqlClient.SqlConnection conn;
                System.Data.SqlClient.SqlCommand cmd;

                using (conn = new System.Data.SqlClient.SqlConnection(connStr))
                using (cmd = new System.Data.SqlClient.SqlCommand(cmd3Str, conn))
                {
                    cmd.Parameters.Add("@AktifMi", System.Data.SqlDbType.Bit, 1, "AktifMi");
                    cmd.Parameters.Add("@Oluşturulduğunda", System.Data.SqlDbType.DateTime2, 7, "Oluşturulduğunda");
                    cmd.Parameters.Add("@OluşturuKimsiId", System.Data.SqlDbType.Int, 4, "OluşturuKimsiId");
                    cmd.Parameters.Add("@Ad", System.Data.SqlDbType.NVarChar, 20, "Ad");
                    cmd.Parameters.Add("@PostaKodu", System.Data.SqlDbType.NVarChar, 5, "PostaKodu");
                    cmd.Parameters.Add("@İlçeId", System.Data.SqlDbType.Int, 4, "İlçeId");

                    worksheet1 = workbook.Worksheets[3];
                    var row = 2; var rowStr = ""; var semtAd = ""; var ilçeId = ""; var postKod = "";

                    cmd.Parameters["@AktifMi"].Value = 1;
                    cmd.Parameters["@Oluşturulduğunda"].Value = DateTime.Now;
                    cmd.Parameters["@OluşturuKimsiId"].Value = 1;

                    conn.Open();

                    do
                    {
                        rowStr = row.ToString();
                        ilçeId = worksheet1.Range["C" + rowStr].Text; 
                        semtAd = worksheet1.Range["E" + rowStr].Text;
                        postKod = worksheet1.Range["G" + rowStr].Text;

                        if (!string.IsNullOrWhiteSpace(ilçeId.Trim()))
                        {
                            cmd.Parameters["@Ad"].Value = semtAd; cmd.Parameters["@İlçeId"].Value = ilçeId;
                            cmd.Parameters["@PostaKodu"].Value = postKod;

                            cmd.ExecuteNonQuery();

                            row++;
                        }
                    } while (!string.IsNullOrWhiteSpace(ilçeId));

                    conn.Close();

                    MessageBox.Show("Semtler Done");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void ImportMahalleler(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Worksheet worksheet1;
                System.Data.SqlClient.SqlConnection conn;
                System.Data.SqlClient.SqlCommand cmd;

                using (conn = new System.Data.SqlClient.SqlConnection(connStr))
                using (cmd = new System.Data.SqlClient.SqlCommand(cmd4Str, conn))
                {
                    cmd.Parameters.Add("@AktifMi", System.Data.SqlDbType.Bit, 1, "AktifMi");
                    cmd.Parameters.Add("@Oluşturulduğunda", System.Data.SqlDbType.DateTime2, 7, "Oluşturulduğunda");
                    cmd.Parameters.Add("@OluşturuKimsiId", System.Data.SqlDbType.Int, 4, "OluşturuKimsiId");
                    cmd.Parameters.Add("@Ad", System.Data.SqlDbType.NVarChar, 20, "Ad");
                    cmd.Parameters.Add("@SemtId", System.Data.SqlDbType.Int, 4, "SemtId");

                    worksheet1 = workbook.Worksheets[4];
                    var row = 2; var rowStr = ""; var mhlAd = ""; var semtId = "";

                    cmd.Parameters["@AktifMi"].Value = 1;
                    cmd.Parameters["@Oluşturulduğunda"].Value = DateTime.Now;
                    cmd.Parameters["@OluşturuKimsiId"].Value = 1;

                    conn.Open();

                    do
                    {
                        rowStr = row.ToString();
                        semtId = worksheet1.Range["D" + rowStr].Text; mhlAd = worksheet1.Range["F" + rowStr].Text;

                        if (!string.IsNullOrWhiteSpace(mhlAd.Trim()))
                        {
                            cmd.Parameters["@Ad"].Value = mhlAd; cmd.Parameters["@SemtId"].Value = semtId;

                            cmd.ExecuteNonQuery();

                            row++;
                        }
                    } while (!string.IsNullOrWhiteSpace(semtId));

                    conn.Close();

                    MessageBox.Show("Mahalleler Done");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            excelApp.Quit();
        }
    }
}
