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
using Microsoft.EntityFrameworkCore;

namespace WpfOnLinux
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TestPostgresConnection(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var dbCtx = new ExampleDbContext() { ConnectionString = "User ID = postgres; Password = XyzAbc321; Server = localhost; Port = 5432; Database = turkexample2; " })
                //    + "Integrated Security = true; Pooling = true;""))
                {
                    var klnclr = dbCtx.Kullanıcılar;

                    if (klnclr != null && klnclr.Any())
                    {
                        foreach (var k in klnclr)
                            personsListBox.Items.Add($"{k.AdSoyad} {k.Girişİsim} {k.MobilNumara}");
                    }

                    //var prsns = dbCtx.persons;

                    //if (prsns != null && prsns.Any())
                    //{
                    //    foreach (var p in prsns)
                    //        personsListBox.Items.Add($"{p.name} {p.birthdate.ToString("yyyy-MM-dd")} {p.email}");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
