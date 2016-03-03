using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.DataClasses
{
    public class Timetable
    {
        public Timetable(List<Day> days)
        {
            _days = days;
        }


        public List<Day> Days 
        {
            set { _days = value; }
            get { return _days; }
        }

        public string GroupName
        {
            set { _groupName = value; }
            get { return _groupName; }
        }

        private List<Day> _days;
        private string _groupName;
    }
}
