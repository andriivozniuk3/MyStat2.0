using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCoreLibrary.DataClasses;
using System.IO;

namespace ClientCoreLibrary.DataClasses
{

    public class CustomFile
    {
        //public Stream File { get; set; }
        //public int? FileIdx { get; set; }

        //public CustomFile(Stream file, int? fileIdx)
        //{
        //    File = file;
        //    FileIdx = fileIdx;
        //}

        public byte[] File { get; set; }
        public int? FileIdx { get; set; }


        public CustomFile(byte[] file, int? fileIdx)
        {
            File = file;
            FileIdx = fileIdx;
        }
    }

}
