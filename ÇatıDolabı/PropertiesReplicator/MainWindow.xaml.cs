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

namespace PropertiesReplicator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> classesFilesNames;
        private string appPath, repPropsFilePath = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            repPropsFilePath = appPath + "\\PropertiesReplication.txt";

            int i = 9; var s = $"{i}";
        }

        private void BrowseButton(object sender, RoutedEventArgs e)
        {
            var ofd = new Microsoft.Win32.OpenFileDialog() 
                { 
                    InitialDirectory= @"C:\Users\pc\Source\Repos", 
                    Multiselect = true 
                };
            var rslt = ofd.ShowDialog();

            if (rslt.HasValue && rslt.Value)
            {
                classesFilesNames = ofd.FileNames.ToList();

                filesListBox.Items.Clear();

                foreach (var aFile in ofd.FileNames)
                    filesListBox.Items.Add(aFile);
            }
        }

        private void StartButton(object sender, RoutedEventArgs e)
        {
            startButton.IsEnabled = false;

            Task.Run(() =>
            {
                foreach (var aClass in classesFilesNames)
                    ReplicateClassProperties(aClass);
            }).ContinueWith((ct) => Dispatcher.Invoke(() => { MessageBox.Show("Done"); startButton.IsEnabled = true; }));
        }

        private void ReplicateClassProperties(string classFile)
        {
            List<string> propertiesNames = new List<string>();
            
            try
            {
                Dispatcher.Invoke(() =>
                {
                    System.IO.File.AppendAllText(repPropsFilePath, new string('=', 50) + Environment.NewLine);
                    System.IO.File.AppendAllText(repPropsFilePath, classFile + Environment.NewLine);
                    System.IO.File.AppendAllText(repPropsFilePath, new string('=', 50) + Environment.NewLine);

                    int loc = 0; var sb = new StringBuilder();
                    var codeLines = System.IO.File.ReadAllLines(classFile);
                    
                    foreach (var aLine in codeLines)
                        if (aLine.EndsWith("{ get; set; }"))
                        {
                            loc = aLine.IndexOf(" { get;") - 1; char ch = aLine[loc]; sb.Clear();

                            do
                            {
                                sb.Append(ch); ch = aLine[--loc];
                            } while (ch != ' ');

                            var propName = new string(sb.ToString().Reverse().ToArray());

                            System.IO.File.AppendAllText(repPropsFilePath, $".{propName} = .{propName}" + Environment.NewLine);
                        }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
