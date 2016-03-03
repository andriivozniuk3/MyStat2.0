using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCoreLibrary.DataClasses;
using System.IO;

namespace ClientCoreLibrary.DataClasses
{
    public class HomeWorkInfo : StudyMaterialInfo
    {
        int? _mark;
        DateTime _datePublic;
        DateTime _datePass;

        TeacherInfo _teacher;
        StudentInfo _student;
        GroupInfo _group;

        public HomeWorkInfo(string theme, string description, int? mark, TeacherInfo teacher, StudentInfo student, GroupInfo group, int? idx)
            : base(theme, null, description, idx)
        {
            _mark = mark;
            _teacher = teacher;
            _student = student;
            _group = group;
            _datePublic = DateTime.Now;
        }

        public int? Mark
        {
            set { _mark = value; }
            get { return _mark; }
        }

        public TeacherInfo Teacher
        {
            set { _teacher = value; }
            get { return _teacher; }
        }

        public StudentInfo Student
        {
            set { _student = value; }
            get { return _student; }
        }

        public GroupInfo Group
        {
            set { _group = value; }
            get { return _group; }
        }

        public DateTime DatePublic
        {
            set { _datePublic = value; }
            get { return _datePublic; }
        }

        public DateTime DatePass
        {
            set { _datePass = value; }
            get { return _datePass; }
        }
    }
}
