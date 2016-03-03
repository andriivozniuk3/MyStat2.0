using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.PublicClasses
{
   
    public abstract class AbstractFactory
    {
        public abstract AbstractAdmin CreateAdmin();
        public abstract AbstractStudent CreateStudent();
        public abstract AbstractTeacher CreateTeacher();
        protected Proxy _proxy;

        protected static AbstractFactory _factory;
        public static AbstractFactory CreateFactory(Proxy proxy)
        {
            throw new NotImplementedException();
        }
    }
}
