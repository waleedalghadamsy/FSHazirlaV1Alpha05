using HazırlaÇekirdek.Valıklar.VeriGünlüğü;
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

namespace HazırlaLogViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string GünlüğüHizmetUrl = "";
        private ObservableCollection<LoggedEvent> loggedEvents;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loggedEvents = new ObservableCollection<LoggedEvent>();
            logListView.ItemsSource = loggedEvents;

            GünlüğüHizmetUrl = "http://localhost:23458/api/Günlükçü";

            //System.
        }

        private async Task GetEventsButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var httpClient = new System.Net.Http.HttpClient() { })
                {
                    var reqNoOfEvents = byte.Parse(noOfEventsTextBox.Text);
                    var jsonStr = await httpClient.GetStringAsync(GünlüğüHizmetUrl + $"/{reqNoOfEvents}");

                    //await GünlükKaydetme(OlaySeviye.Uyarı, $"Semtler: {jsonStr}");

                    if (!string.IsNullOrWhiteSpace(jsonStr))
                    {
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Günlük>>(jsonStr);

                        if (result != null && result.Any())
                        {
                            loggedEvents.Clear();
                            loggedEvents = new ObservableCollection<LoggedEvent>(
                                from r in result
                                select new LoggedEvent()
                                {
                                    Id = r.Id.ToString(),
                                    EventDatetime = $"{r.Tarih} {r.Zaman}",
                                    Level = r.Seviye.ToString(),
                                    Source = r.Kaynak,
                                    Message = r.Mesaj
                                });

                            logListView.Items.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
