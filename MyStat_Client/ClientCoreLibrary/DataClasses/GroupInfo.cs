using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.DataClasses
{
    public class GroupInfo
    {
        public GroupInfo(string name, List<StudentInfo> students) 
        {
            _students = students;
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<StudentInfo> Students 
        {
            get { return _students; }
            set { _students = value; }
        }

        private string _name;
        private List<StudentInfo> _students;
    }
}
