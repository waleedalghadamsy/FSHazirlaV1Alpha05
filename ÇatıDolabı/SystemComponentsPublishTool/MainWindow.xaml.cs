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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void PublishWebProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Task.Run(() =>
                {
                    try
                    {


                        webProjectParams = "-f netcoreapp3.0 -c Release -o \"C:\\For Waleed\\DeploymentArea\\BisiparişWebV1Alpha2\""
                        + " \"C:\\Users\\pc\\Source\\Repos\\Bisipariş V 1_0Alpha04\\3 Gösterim\\Web\\BisiparişWeb\\BisiparişWeb.csproj\"";

                        using (var prs = new System.Diagnostics.Process
                        {
                            StartInfo = new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = "cmd.exe",
                                Arguments = $"/k dotnet publish {webProjectParams}",
                                UseShellExecute = true,
                                CreateNoWindow = true,
                                WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                            }
                        })
                        {
                            Dispatcher.Invoke(() =>
                            {
                                webPrjLabel.Foreground = Brushes.Orange; webPrjLabel.Content = "Publishing...";
                                webPrjLabel.Visibility = Visibility.Visible;
                            });

                            using (var iisSrvr = new Microsoft.Web.Administration.ServerManager())
                            {
                                //DisplayMessage("Stopping IIS site...");

                                iisSrvr.Sites["Bisipariş"].Stop();

                                //DisplayMessage("Starting process...");

                                prs.Start();

                                do { } while (!prs.HasExited);

                                iisSrvr.Sites["Bisipariş"].Start();
                            }
                            Dispatcher.Invoke(() =>
                            {
                                webPrjLabel.Foreground = Brushes.Green; webPrjLabel.Content = "Done";
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        DisplayMessage(ex.ToString());
                    }
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void PublishBackendServiceProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                backendServiceParams = "-f netcoreapp3.0 -c Release -o \"C:\\For Waleed\\DeploymentArea\\BisiparişArkaUçİşlemlerHizmet\""
    + " \"C:\\Users\\pc\\Source\\Repos\\Bisipariş V 1_0Alpha04\\2 Altyapı\\Hizmetler\\ArkaUçİşlemlerHizmet\\ArkaUçİşlemlerHizmet.csproj\"";
                using (var prs = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/k dotnet publish {backendServiceParams}",
                        UseShellExecute = true,
                        CreateNoWindow = true,
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                    }
                })
                {
                    Dispatcher.Invoke(() =>
                    {
                        bkEndPrjLabel.Foreground = Brushes.Orange; bkEndPrjLabel.Content = "Publishing...";
                        bkEndPrjLabel.Visibility = Visibility.Visible;
                    });

                    using (var iisSrvr = new Microsoft.Web.Administration.ServerManager())
                    {
                        //DisplayMessage("Stopping IIS site...");

                        iisSrvr.Sites["BisiparişArkaUçİşlemlerHizmet"].Stop();

                        //DisplayMessage("Starting process...");

                        prs.Start();

                        do { } while (!prs.HasExited);

                        iisSrvr.Sites["BisiparişArkaUçİşlemlerHizmet"].Start();
                    }
                    
                    Dispatcher.Invoke(() =>
                    {
                        bkEndPrjLabel.Foreground = Brushes.Green; bkEndPrjLabel.Content = "Done";
                    });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void PublishSecurityServiceProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                securityServiceParams = "-f netcoreapp3.0 -c Release -o \"C:\\For Waleed\\DeploymentArea\\BisiparişGüvenlikHizmet\""
    + " \"C:\\Users\\pc\\Source\\Repos\\Bisipariş V 1_0Alpha04\\2 Altyapı\\Hizmetler\\GüvenlikHizmet\\GüvenlikHizmet.csproj\"";

                using (var prs = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/k dotnet publish {securityServiceParams}",
                        UseShellExecute = true,
                        CreateNoWindow = true,
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                    }
                })
                {
                    Dispatcher.Invoke(() =>
                    {
                        secPrjLabel.Foreground = Brushes.Orange; secPrjLabel.Content = "Publishing...";
                        secPrjLabel.Visibility = Visibility.Visible;
                    });

                    using (var iisSrvr = new Microsoft.Web.Administration.ServerManager())
                    {
                        iisSrvr.Sites["BisiparişGüvenlikHizmet"].Stop();

                        prs.Start();

                        do { } while (!prs.HasExited);

                        iisSrvr.Sites["BisiparişGüvenlikHizmet"].Start();
                    }

                    Dispatcher.Invoke(() =>
                    {
                        secPrjLabel.Foreground = Brushes.Green; secPrjLabel.Content = "Done";
                    });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void PublishLoggerServiceProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loggerServiceParams = "-f netcoreapp3.0 -c Release -o \"C:\\For Waleed\\DeploymentArea\\BisiparişGünlükHizmet\""
            + " \"C:\\Users\\pc\\Source\\Repos\\Bisipariş V 1_0Alpha04\\2 Altyapı\\Hizmetler\\OlayGünlüğüHizmet\\OlayGünlüğüHizmet.csproj\"";

                using (var prs = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/k dotnet publish {loggerServiceParams}",
                        UseShellExecute = true,
                        CreateNoWindow = true,
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                    }
                })
                {
                    Dispatcher.Invoke(() =>
                    {
                        logPrjLabel.Foreground = Brushes.Orange; logPrjLabel.Content = "Publishing...";
                        logPrjLabel.Visibility = Visibility.Visible;
                    });

                    using (var iisSrvr = new Microsoft.Web.Administration.ServerManager())
                    {
                        iisSrvr.Sites["BisiparişGünlükHizmet"].Stop();

                        prs.Start();

                        do { } while (!prs.HasExited);

                        iisSrvr.Sites["BisiparişGünlükHizmet"].Start();
                    }

                    Dispatcher.Invoke(() =>
                    {
                        logPrjLabel.Foreground = Brushes.Green; logPrjLabel.Content = "Done";
                    });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void DisplayMessage(string msj)
        {
            Dispatcher.Invoke(() => MessageBox.Show(msj));
        }
    }
}
