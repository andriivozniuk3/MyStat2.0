using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.DataClasses
{
    public class Advertisement
    {
        public Advertisement(string title, string info, DateTime timePublication)
        {
            _title = title;
            _info = info;
            _timePublication = timePublication;
        }
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        public string Info
        {
            set { _info = value; }
            get { return _info; }
        }
        public DateTime TimePublication
        {
            set { _timePublication = value; }
            get { return _timePublication; }
        }

        private string _title;
        private string _info;
        private DateTime _timePublication;
    }
}
