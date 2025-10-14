using SimpleProjectStopwatch.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleProjectStopwatch.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<TimeEntry> TimeEntries { get; set; }
        public TimeSpan TotalTime => TimeEntries?.Aggregate(TimeSpan.Zero, (sum, entry) => sum + entry.Duration) ?? TimeSpan.Zero;

        public ICommand EditDetails => new RelayCommand(async o =>
        {
            var dialog = new Views.Dialogs.AEProject(this);
            await dialog.ShowAsync();
        });
        public ICommand DeleteProject => new RelayCommand(o =>
        {
            ObjectRepository.Database.DeleteProject(Id);
        });
    }
}
