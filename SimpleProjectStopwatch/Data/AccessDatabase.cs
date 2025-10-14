using System;
using System.Collections.Generic;
using System.Linq;
using SimpleProjectStopwatch.Models;

namespace SimpleProjectStopwatch.Data
{
    public class AccessDatabase
    {
        private readonly ApplicationDbContext _context;

        public AccessDatabase(ApplicationDbContext context)
        {
            _context = context;
        }   

        // Project methods
        public void SaveProject(Project project)
        {
            if (project.Id == 0)
            {
                _context.Projects.Add(project);
            }
            else
            {
                _context.Projects.Update(project);
            }
            _context.SaveChanges();
        }

        public void DeleteProject(int projectId)
        {
            var project = _context.Projects.Find(projectId);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }

        public Project GetProject(int projectId)
        {
            return _context.Projects
                .Where(p => p.Id == projectId)
                .FirstOrDefault();
        }

        public List<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }

        public void SaveTimeEntry(TimeEntry timeEntry)
        {
            if (timeEntry.Id == 0)
            {
                _context.TimeEntries.Add(timeEntry);
            }
            else
            {
                _context.TimeEntries.Update(timeEntry);
            }
            _context.SaveChanges();
        }

        public void DeleteTimeEntry(int timeEntryId)
        {
            var timeEntry = _context.TimeEntries.Find(timeEntryId);
            if (timeEntry != null)
            {
                _context.TimeEntries.Remove(timeEntry);
                _context.SaveChanges();
            }
        }

        public TimeEntry GetTimeEntry(int timeEntryId)
        {
            return _context.TimeEntries
                .Where(te => te.Id == timeEntryId)
                .FirstOrDefault();
        }

        public List<TimeEntry> GetTimeEntries()
        {
            return _context.TimeEntries.ToList();
        }
    }
}
