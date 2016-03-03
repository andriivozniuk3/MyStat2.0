
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCoreLibrary.Implementation;
namespace ClientCoreLibrary.PublicClasses
{
    public class UniversityFactory : AbstractFactory
    {
        private UniversityFactory(Proxy proxy) 
        {
            _proxy = proxy;
        }
        public static AbstractFactory CreateFactory(Proxy proxy)
        {
            if (_factory == null)
                _factory = new UniversityFactory(proxy);
            return _factory;
        }

        public override AbstractAdmin CreateAdmin()
        {
            return Admin.GetInstance(_proxy);
        }
        public override AbstractStudent CreateStudent()
        {
            return Student.GetInstance(_proxy);
        }
        public override AbstractTeacher CreateTeacher()
        {
            return Teacher.GetInstance(_proxy);
        }
    }
}
