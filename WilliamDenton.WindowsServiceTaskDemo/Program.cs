using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WilliamDenton.WindowsServiceTaskDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //this is used for debug from Visual Studio.
            using (var svc = new Service1())
            {
                Console.WriteLine("Starting Service...");
                svc.DebugOnStart();
                Console.WriteLine("Started...");

                Console.WriteLine("Push Enter To Stop");
                Console.ReadLine();

                Console.WriteLine("Stopping Service...");
                svc.DebugOnStop();
                Console.WriteLine("Stopped...");
            }


            //This is used when running service properly
            //also change applicatino type back to Windows Application rather then Console Application

            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new Service1()
            //};
            //ServiceBase.Run(ServicesToRun);
        }
    }
}
