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
    internal class AETimeEntryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private TimeEntry? timeEntry = new();

        public TimeEntry? TimeEntry
        {
            get { return timeEntry; }
            set { timeEntry = value;
                OnPropertyChanged();
            }
        }

        public ICommand SetTimeToNow => new RelayCommand(o =>
        {
            if(int.Parse(o.ToString()) is int mode)
            {
                if(mode == 0) // Start Time
                {
                    if (TimeEntry != null)
                    {
                        TimeEntry.StartTime = DateTime.Now;
                        OnPropertyChanged(nameof(TimeEntry));
                    }
                }
                else if(mode == 1) // End Time
                {
                    if (TimeEntry != null)
                    {
                        TimeEntry.EndTime = DateTime.Now;
                        OnPropertyChanged(nameof(TimeEntry));
                    }
                }
            }
            OnPropertyChanged(nameof(TimeEntry.Duration));
        });

        public ICommand Save => new RelayCommand(o =>
        {
            ObjectRepository.Database.SaveTimeEntry(TimeEntry!);
        });

        private ObservableCollection<Project> projects;
        public ObservableCollection<Project> Projects
        {
            get { return projects; }
            set { projects = value;
                OnPropertyChanged();
            }
        }


        public AETimeEntryViewModel()
        {
            LoadProjects();
        }
        public AETimeEntryViewModel(TimeEntry timeEntry)
        {
            TimeEntry = timeEntry;
            LoadProjects();
        }
        void LoadProjects()
        {
            Projects = new(ObjectRepository.Database.GetProjects());

        }
    }
}
