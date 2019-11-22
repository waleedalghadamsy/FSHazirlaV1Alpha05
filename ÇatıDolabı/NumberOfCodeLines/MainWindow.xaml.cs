using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace NumberOfCodeLines
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<CodeFile> codeFiles;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButtonClick(object sender, RoutedEventArgs e)
        {
            var fbd = new WPFFolderBrowser.WPFFolderBrowserDialog() { InitialDirectory = "C:\\" };

            var rslt = fbd.ShowDialog();
            var folderPath = "";

            if (rslt.HasValue && rslt.Value)
                folderPath = pathTextBox.Text = fbd.FileName;

            filesListView.ItemsSource = codeFiles = new ObservableCollection<CodeFile>();

            Task.Run(() =>
              {
                  try
                  {
                      GetNoOfCodeLines(folderPath);

                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show("BrowseButton: " + ex.ToString());
                  }
              });
        }

        private void GetNoOfCodeLines(string path)
        {
            try
            {
                var csFiles = System.IO.Directory.GetFiles(path, "*.cs");

                if (csFiles != null && csFiles.Any())
                {
                    //totalFiles += csFiles.Length; noOfFilesLabel.Content = totalFiles.ToString();

                    foreach (var csFile in csFiles)
                    {
                        var allLines = System.IO.File.ReadAllLines(csFile);
                        var noOfLines = allLines.Length;
                        var noOfEmptyLines = allLines.Count(l => l.Length == 0);
                        var noOCommentLines = allLines.Count(l => l.StartsWith("//"));
                        var nLines = noOfLines - noOfEmptyLines - noOCommentLines;

                        if (FileCounted != null)
                            FileCounted(this, new FileCountedEventArgs() { CsFileName = csFile, NoOfCsLines = nLines });
                    }
                }

                var htmlFiles = System.IO.Directory.GetFiles(path, "*.cshtml");

                if (htmlFiles != null && htmlFiles.Any())
                {
                    foreach (var htmlFile in htmlFiles)
                    {
                        var allHtLines = System.IO.File.ReadAllLines(htmlFile);
                        var noOfHtLines = allHtLines.Length;
                        var noOfHtEmptyLines = allHtLines.Count(l => l.Length == 0);
                        var noOHtCommentLines = allHtLines.Count(l => l.StartsWith("//"));
                        var nHtLines = noOfHtLines - noOfHtEmptyLines - noOHtCommentLines;

                        if (FileCounted != null)
                            FileCounted(this, new FileCountedEventArgs() { HtmlFileName = htmlFile, NoOfHtmlLines = nHtLines });
                    }
                }

                var subFolders = System.IO.Directory.EnumerateDirectories(path);

                if (subFolders != null && subFolders.Any())
                    subFolders.ToList().ForEach(sf => GetNoOfCodeLines(sf));
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetNoOfLines: " + ex.ToString());
            }
        }

        int totalCsLines = 0, totalCsFiles = 0, totalHtmlLines = 0, totalHtmlFiles = 0;

        private void FileCountedHandler(object source, FileCountedEventArgs e)
        {
            string fileNameOnly = "";
            int noOfLines = 0;

            Dispatcher.Invoke(() =>
            {

                var fileExt = !string.IsNullOrWhiteSpace(e.CsFileName)
                                    ? System.IO.Path.GetExtension(e.CsFileName) : System.IO.Path.GetExtension(e.HtmlFileName);
                fileNameOnly = !string.IsNullOrWhiteSpace(e.CsFileName) 
                                    ? System.IO.Path.GetFileName(e.CsFileName) : System.IO.Path.GetFileName(e.HtmlFileName);
                noOfLines = e.NoOfCsLines > 0 ? e.NoOfCsLines : e.NoOfHtmlLines;

                codeFiles.Add(new CodeFile() { FileName = fileNameOnly, NoOfLines = noOfLines.ToString() });

                filesListView.Items.Refresh();

                totalCsLines += e.NoOfCsLines; totalHtmlLines += e.NoOfHtmlLines;

                if (fileExt.Equals(".cs")) totalCsFiles++; else totalHtmlFiles++;

                noOfCSFilesLabel.Content = totalCsFiles.ToString(); nCSLinesLabel.Content = totalCsLines.ToString();
                noOfHtmlFilesLabel.Content = totalHtmlFiles.ToString(); nHtmlLinesLabel.Content = totalHtmlLines.ToString();

                progressBar.Value++;
            });
        }

        private void StartCountingButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private event EventHandler<FileCountedEventArgs> FileCounted;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileCounted += FileCountedHandler;
        }
    }
}
