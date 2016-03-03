using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.DataClasses
{
    public class Request
    {
        public Request(UnitInfo sender, UnitInfo receiver, DateTime date, string text)
        {
            _text = text;
            _date = date;
            _sender = sender;
            _receiver = receiver;
        }

        public string Text
        {
            set { _text = value; }
            get { return _text; }
        }
        public DateTime Date
        {
            set { _date = value; }
            get { return _date; }
        }
        public UnitInfo Sender
        {
            set { _sender = value; }
            get { return _sender; }
        }
        public UnitInfo Receiver
        {
            set { _receiver = value; }
            get { return _receiver; }
        }


        private string _text;
        private DateTime _date;
        private UnitInfo _sender;
        private UnitInfo _receiver;
    }
}
