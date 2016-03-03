using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCoreLibrary.PublicClasses;
using ClientCoreLibrary.DataClasses;

namespace ClientCoreLibrary.Implementation
{
    class Admin : AbstractAdmin
    {
        private Admin(Proxy proxy)
            : base(proxy)
        { }

        private static Admin _instance;
        public static Admin GetInstance(Proxy proxy)
        {
            if (_instance != null)
                return _instance;
            return (_instance = new Admin(proxy));
        }


        public override void AddAdvertisement(string title, string info, DateTime timePublication)
        {
            Advertisement avertisement = new Advertisement(title, info, timePublication);
            _proxy.SendRequest(RequestType.ANewAdvertisement, avertisement);
        }

        public override List<Advertisement> GetAllAdvertisements()
        {
            return (List<Advertisement>)_proxy.SendRequest(RequestType.GetAllAdvertisements, null);
        }

        public override void LoadTimetableForGroup(string groupName)
        {
            this._currentTimetable = (Timetable)_proxy.SendRequest(RequestType.SGetTimetableForGroup, groupName);
        }

        public override void SetLesson(int dayIdx, int lessonIdx, string newLesson)
        {
            _currentTimetable.Days[dayIdx].Lessons[lessonIdx].Name = newLesson;
            _proxy.SendRequest(RequestType.ASetLesson, new object[]{_currentTimetable, dayIdx, lessonIdx, newLesson});
        }


        public override void SetTeacher(int dayIdx, int lessonIdx, string newTeacher)
        {
            _currentTimetable.Days[dayIdx].Lessons[lessonIdx].Teacher = newTeacher;
            _proxy.SendRequest(RequestType.ASetTeacher, new object[] { _currentTimetable, dayIdx, lessonIdx, newTeacher });
        }

        public override List<string> GetGroupNames()
        {
            return (List<string>)_proxy.SendRequest(RequestType.GetGroupNames, null);
        }

        public override void AddStudent(string firstname, string lastname, string login, string password, string groupName)
        {
            StudentInfo student = new StudentInfo(firstname, lastname, login, password, groupName);
            _proxy.SendRequest(RequestType.AAddNewStudent, student);
        }

        public override void RemoveStudent(string groupName, string firstname, string lastname)
        {
            _proxy.SendRequest(RequestType.ARemoveStudent, new string[] { groupName,  firstname, lastname});
        }

        public override List<Request> GetRequests()
        {
            return (List<Request>)_proxy.SendRequest(RequestType.GetRequests, UnitType.Admin);
        }

        public override void SendRequest(UnitInfo receiver, string text)
        {
            Request request = new Request(new AdminInfo(),receiver , DateTime.Now, text );
            _proxy.SendRequest(RequestType.SendRequset, request);
        }

        public override List<StudentInfo> GetStudentsByGroupName(string groupName)
        {
            return (List<StudentInfo>)_proxy.SendRequest(RequestType.AGetStudentsByGroupName, groupName);
        }


        public override void DeleteLesson(int dayIdx, int lessonIdx)
        {
            _currentTimetable.Days[dayIdx].Lessons[lessonIdx] = null;
            _proxy.SendRequest(RequestType.ADeleteLesson, new object[] { _currentTimetable, dayIdx, lessonIdx });
        }

        public override void CreateLesson(int dayIdx, int lessonIdx, Lesson newLesson)
        {
            _currentTimetable.Days[dayIdx].Lessons[lessonIdx] = newLesson;
            _proxy.SendRequest(RequestType.ACreateLesson, new object[] { _currentTimetable, dayIdx, lessonIdx, newLesson });
        }
    }
}
