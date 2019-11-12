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

namespace SystemComponentsPublishTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string loggerServiceParams, securityServiceParams, backendServiceParams, webProjectParams;
        //System.Diagnostics.Process olayGünlükHizmetSüreci, arkaUçHizmetSüreci, webSüreci;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PublishWebProject_Click(object sender, RoutedEventArgs e)
        {
            webProjectParams = "-f netcoreapp3.0 -c Release -o \"C:\\For Waleed\\DeploymentArea\\BisiparişWebV1Alpha2\""
                + " \"C:\\Users\\pc\\Source\\Repos\\Bisipariş V 1_0Alpha03\\3 Gösterim\\Web\\BisiparişWeb\\BisiparişWeb.csproj\""; ;

            new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/k dotnet publish {webProjectParams}",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                }
            }.Start();
        }

        private void PublishBackendServiceProject_Click(object sender, RoutedEventArgs e)
        {
            backendServiceParams = "-f netcoreapp3.0 -c Release -o \"C:\\For Waleed\\DeploymentArea\\BisiparişArkaUçİşlemlerHizmet\""
    + " \"C:\\Users\\pc\\Source\\Repos\\Bisipariş V 1_0Alpha03\\2 Altyapı\\Hizmetler\\ArkaUçİşlemlerHizmet\\ArkaUçİşlemlerHizmet.csproj\"";

            new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/k dotnet publish {backendServiceParams}",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                }
            }.Start();
        }

        private void PublishSecurityServiceProject_Click(object sender, RoutedEventArgs e)
        {
            securityServiceParams = "-f netcoreapp3.0 -c Release -o \"C:\\For Waleed\\DeploymentArea\\BisiparişGüvenlikHizmet\""
    + " \"C:\\Users\\pc\\Source\\Repos\\Bisipariş V 1_0Alpha03\\2 Altyapı\\Hizmetler\\GüvenlikHizmet\\GüvenlikHizmet.csproj\"";

            new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/k dotnet publish {securityServiceParams}",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                }
            }.Start();
        }

        private void PublishLoggerServiceProject_Click(object sender, RoutedEventArgs e)
        {
            loggerServiceParams = "-f netcoreapp3.0 -c Release -o \"C:\\For Waleed\\DeploymentArea\\BisiparişGünlükHizmet\""
            + " \"C:\\Users\\pc\\Source\\Repos\\Bisipariş V 1_0Alpha03\\2 Altyapı\\Hizmetler\\OlayGünlüğüHizmet\\OlayGünlüğüHizmet.csproj\"";
            new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/k dotnet publish {loggerServiceParams}",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                }
            }.Start();
        }
    }
}
