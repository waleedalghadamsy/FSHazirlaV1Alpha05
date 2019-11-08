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
        string olayGünlükHizmetYolu, arkaUçHizmetYolu, webYolu;
        System.Diagnostics.Process olayGünlükHizmetSüreci, arkaUçHizmetSüreci, webSüreci;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SistemBaşlaButon_Tıklamak(object sender, RoutedEventArgs e)
        {
            olayGünlükHizmetYolu = "\"C:\\For Waleed\\DeploymentArea\\BisiparişGünlükHizmet\\OlayGünlüğüHizmet.dll\"";
            arkaUçHizmetYolu = "\"C:\\For Waleed\\DeploymentArea\\BisiparişArkaUçİşlemlerHizmet\\ArkaUçİşlemlerHizmet.dll\"";
            webYolu = "\"C:\\For Waleed\\DeploymentArea\\BisiparişWebV1Alpha2\\BisiparişWeb.dll\"";

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

            olayGünlükHizmetSüreci.Start(); arkaUçHizmetSüreci.Start(); webSüreci.Start();
        }
    }
}
