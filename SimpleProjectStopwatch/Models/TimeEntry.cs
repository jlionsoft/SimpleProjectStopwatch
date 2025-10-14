using SimpleProjectStopwatch.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SimpleProjectStopwatch.Models
{
    public class TimeEntry : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Duration));
            }
        }

        private DateTime? endTime;
        public DateTime? EndTime
        {
            get { return endTime; }
            set { endTime = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Duration));
            }
        }

        public TimeSpan Duration => (EndTime ?? DateTime.Now) - StartTime;
        public string Description { get; set; }

        public ICommand EditDetails => new RelayCommand(o =>
        {
            var dialog = new Views.Dialogs.AETimeEntry(this);
            _ = dialog.ShowAsync();
        });
        public ICommand DeleteEntry => new RelayCommand(o =>
        {
            ObjectRepository.Database.DeleteTimeEntry(Id);
        });
    }
}