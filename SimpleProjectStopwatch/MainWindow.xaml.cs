using ModernWpf.Controls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleProjectStopwatch
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

        private void NavigationView_SelectionChanged(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            string? content = (sender?.SelectedItem as NavigationViewItem)?.Tag?.ToString();

            if (string.IsNullOrEmpty(content))
            {
                content = "Erfassung";
            }

            switch (content)
            {
                case "Erfassung":
                    sender.Header = "Zeiterfassung";
                    NavView.Content = new Views.TimeEntryView();
                    break;
                case "Projekte":
                    sender.Header = "Projekte";
                    NavView.Content = new Views.ProjectView();
                    break;

                default:
                    sender.Header = "Projekte";
                    break;
            }
        }

        private void NavView_Initialized(object sender, EventArgs e)
        {
            NavigationView_SelectionChanged((sender as NavigationView)!, null!);
        //    (sender as NavigationView)!.Header = "Zeiterfassung";
        //    (sender as NavigationView)!.Content = new Views.TimeEntryView();
        }
    }
}