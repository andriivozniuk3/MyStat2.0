using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.DataClasses
{
    public class Lesson
    {
        public Lesson(string name, string teacher, string group, DateTime time) 
        {
            _name = name;
            _teacher = teacher;
            _group = group;
            _time = time;
        }
        public string Name
        {
            set { _name = value; }
            get { return _name;}
        }
        public string Teacher
        {
            set { _teacher = value; }
            get { return _teacher; }
        }
        public string Group
        {
            set { _group = value; }
            get { return _group; }
        }
        public DateTime Time
        {
            set { _time = value; }
            get { return _time; }
        }

        private DateTime _time;
        private string _name;
        private string _teacher;
        private string _group;
     
    }
}
