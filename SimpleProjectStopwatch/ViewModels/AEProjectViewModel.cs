using SimpleProjectStopwatch.Commands;
using SimpleProjectStopwatch.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleProjectStopwatch.ViewModels
{
    internal class AEProjectViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Project project = new();
        public Project Project
        {
            get { return project; }
            set { project = value;
                OnPropertyChanged();
            }
        }

        public ICommand Save => new RelayCommand(o =>
        {
            ObjectRepository.Database.SaveProject(Project);
        });

        public AEProjectViewModel()
        {
            
        }
        public AEProjectViewModel(Project project)
        {
            Project = project;
        }

    }
}
