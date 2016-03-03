using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ServiceDll;
using System.ServiceModel;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        ServiceHost sh = new ServiceHost(typeof(Service));
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            sh.Open();
        }

        protected override void OnStop()
        {
            sh.Close();
        }
    }
}
