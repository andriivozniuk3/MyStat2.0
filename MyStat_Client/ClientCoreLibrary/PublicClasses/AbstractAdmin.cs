using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCoreLibrary.DataClasses;

namespace ClientCoreLibrary.PublicClasses
{
    public enum UnitType { Teacher, Student, Admin };
    public abstract class AbstractAdmin : AbstractUnit
    {
        
        public AbstractAdmin(Proxy proxy) : base(proxy) 
        { }

        public abstract void AddAdvertisement(string title, string info, DateTime timePublication);
        public abstract List<Advertisement> GetAllAdvertisements();
        public abstract void LoadTimetableForGroup(string groupName);
        public abstract void SetLesson(int dayIdx, int lessonIdx, string newLesson);
        public abstract void SetTeacher( int dayIdx, int lessonIdx, string newTeacher);
        public abstract void DeleteLesson(int dayIdx, int lessonIdx);
        public abstract void CreateLesson(int dayIdx, int lessonIdx, Lesson newLesson);
        public abstract List<string> GetGroupNames();
        public abstract void AddStudent(string firstname, string lastname, string login, string password, string groupName);
        public abstract void RemoveStudent(string groupName, string firstname, string lastname);
        public abstract List<StudentInfo> GetStudentsByGroupName(string groupName);
        public Timetable CurrentTimetable
        {
            set { _currentTimetable = value; }
            get { return _currentTimetable; }
        }

        protected Timetable _currentTimetable;

    }
}
