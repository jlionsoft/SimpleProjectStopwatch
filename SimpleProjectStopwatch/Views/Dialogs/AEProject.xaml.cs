using ModernWpf.Controls;
using SimpleProjectStopwatch.Models;
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
    /// Interaction logic for AEProject.xaml
    /// </summary>
    public partial class AEProject : ContentDialog
    {
        public AEProject()
        {
            InitializeComponent();
            Title = "Neues Projekt";
            DataContext = new ViewModels.AEProjectViewModel();
        }
        public AEProject(Project project)
        {
            InitializeComponent();
            Title = "Projekt bearbeiten";
            DataContext = new ViewModels.AEProjectViewModel(project);
        }
    }
}
