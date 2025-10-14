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
    internal class ProjectViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Project> projects = new();
        public ObservableCollection<Project> Projects
        {
            get { return projects; }
            set { projects = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateNew => new RelayCommand(async o =>
        {
            var dialog = new Views.Dialogs.AEProject();
            await dialog.ShowAsync();
            LoadProjects();
        });

        public ProjectViewViewModel()
        {
            LoadProjects();
        }
        void LoadProjects()
        {
            Projects = new(ObjectRepository.Database.GetProjects());
        }
    }
}
