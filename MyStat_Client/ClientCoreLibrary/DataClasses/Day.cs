using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.DataClasses
{
    public class Day
    {
        public Day(List<Lesson> lessons)
        {
            _lessons = lessons;
        }


        public List<Lesson> Lessons 
        {
            get { return _lessons; }
            set { _lessons = value; }
        }

        private List<Lesson> _lessons;
    }
}
