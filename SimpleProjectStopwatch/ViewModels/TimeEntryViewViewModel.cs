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
    internal class TimeEntryViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<TimeEntry> timeEntries = new();
        public ObservableCollection<TimeEntry> TimeEntries
        {
            get { return timeEntries; }
            set { timeEntries = value;
                OnPropertyChanged();
            }
        }

        public TimeEntryViewViewModel()
        {
            LoadTimeEntries();
        }
        public ICommand CreateNew => new RelayCommand(async o =>
        {
            var dialog = new Views.Dialogs.AETimeEntry();
            await dialog.ShowAsync();
            LoadTimeEntries();
        });

        void LoadTimeEntries()
        {
            TimeEntries = new(ObjectRepository.Database.GetTimeEntries()
                .OrderByDescending(te=>te.EndTime));
        }

    }
}
