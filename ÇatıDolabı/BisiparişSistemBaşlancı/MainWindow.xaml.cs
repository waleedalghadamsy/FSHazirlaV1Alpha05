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

namespace BisiparişSistemBaşlancı
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string olayGünlükHizmetYolu, güvenlikHizmetYolu, arkaUçHizmetYolu, maliHizmetYolu, webYolu, önUçHizmetYolu;
        System.Diagnostics.Process olayGünlükHizmetSüreci, güvenlikHizmetSüreci, arkaUçHizmetSüreci, maliHizmetSüreci, webSüreci,
            önUçHizmetSüreci;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SistemBaşlaButon_Tıklamak(object sender, RoutedEventArgs e)
        {
            olayGünlükHizmetYolu = "\"C:\\For Waleed\\DeploymentArea\\HazırlaGünlükHizmet\\OlayGünlüğüHizmet.dll\"";
            güvenlikHizmetYolu = "\"C:\\For Waleed\\DeploymentArea\\HazırlaGüvenlikHizmet\\GüvenlikHizmet.dll\"";
            arkaUçHizmetYolu = "\"C:\\For Waleed\\DeploymentArea\\HazırlaArkaUçHizmet\\ArkaUçİşlemlerHizmet.dll\"";
            maliHizmetYolu = "\"C:\\For Waleed\\DeploymentArea\\HazırlaMaliHizmet\\MaliHizmet.dll\"";
            webYolu = "\"C:\\For Waleed\\DeploymentArea\\HazırlaWebArkaUçV1Alpha5\\HazırlaWebArkaUç.dll\"";
            //önUçHizmetYolu = "\"C:\\For Waleed\\DeploymentArea\\BisiparişGünlükHizmet\\OlayGünlüğüHizmet.dll\"";

            olayGünlükHizmetSüreci = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/k dotnet {olayGünlükHizmetYolu}",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                }
            };

            güvenlikHizmetSüreci = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/k dotnet {güvenlikHizmetYolu}",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                }
            };

            arkaUçHizmetSüreci = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/k dotnet {arkaUçHizmetYolu}",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                }
            };

            maliHizmetSüreci = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/k dotnet {maliHizmetYolu}",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                }
            };

            webSüreci = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/k dotnet {webYolu}",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                }
            };

            //önUçHizmetSüreci = new System.Diagnostics.Process
            //{
            //    StartInfo = new System.Diagnostics.ProcessStartInfo
            //    {
            //        FileName = "cmd.exe",
            //        Arguments = $"/k dotnet {önUçHizmetYolu}",
            //        UseShellExecute = true,
            //        CreateNoWindow = true,
            //        WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
            //    }
            //};

            olayGünlükHizmetSüreci.Start(); güvenlikHizmetSüreci.Start(); arkaUçHizmetSüreci.Start(); //maliHizmetSüreci.Start();
            webSüreci.Start();
            //önUçHizmetSüreci.Start();
        }
    }
}
