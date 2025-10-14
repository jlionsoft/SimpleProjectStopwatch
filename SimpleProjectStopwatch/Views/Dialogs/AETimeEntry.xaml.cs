using ModernWpf.Controls;
using SimpleProjectStopwatch.Models;
using SimpleProjectStopwatch.ViewModels;
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

namespace SimpleProjectStopwatch.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for AETimeEntry.xaml
    /// </summary>
    public partial class AETimeEntry : ContentDialog
    {
        public AETimeEntry()
        {
            InitializeComponent();
            Title = "Neuer Zeiteintrag";
            DataContext = new AETimeEntryViewModel();
        }
        public AETimeEntry(TimeEntry timeEntry)
        {
            InitializeComponent();
            Title = "Zeiteintrag bearbeiten";
            DataContext = new AETimeEntryViewModel(timeEntry);
        }
    }
}
