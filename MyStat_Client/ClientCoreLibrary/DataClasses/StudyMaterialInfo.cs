using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.DataClasses
{
    public class StudyMaterialInfo
    {
        string _theme;
        string _name;
        string _description;
        int? fileIdx;

        public StudyMaterialInfo(string theme, string name, string description, int? idx)
        {
            _theme = theme;
            _description = description;
            fileIdx = idx;
            _name = name;

        }

        public int? FileIdx
        {
            get { return fileIdx; }
            set { fileIdx = value; }
        }

        public string Theme
        {
            set { _theme = value; }
            get { return _theme; }
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
    }
}
