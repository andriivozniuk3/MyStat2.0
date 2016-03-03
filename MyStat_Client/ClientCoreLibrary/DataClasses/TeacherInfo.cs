using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.DataClasses
{
    public class TeacherInfo: UnitInfo
    {
        public TeacherInfo(string firstname, string lastname, List<GroupInfo> groups)
        :base(firstname, lastname)
        {
            _groups = groups;
        }

        public List<string> Lessons 
        {
            set { _lessons = value; }
            get { return _lessons; }
        }

        public List<GroupInfo> Groups
        {
            set { _groups = value; }
            get { return _groups; }
        }
        private List<GroupInfo> _groups;
        private List<string> _lessons;
    }
}
