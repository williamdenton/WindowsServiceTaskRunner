using System;
using System.ServiceProcess;

namespace WilliamDenton.WindowsServiceTaskDemo
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

#if DEBUG
        public void DebugOnStart()
        {
            OnStart(null);
        }

        public void DebugOnStop()
        {
            OnStop();
        }
#endif



        private LoopRunner _demoRunner;

        protected override void OnStart(string[] args)
        {
            Console.WriteLine($"OnStart Thread: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            _demoRunner = new LoopRunner(new DemoUnitOfWork());
            _demoRunner.Start();
        }

        protected override void OnStop()
        {
            Console.WriteLine($"OnStop Thread: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            _demoRunner.Stop();
        }
    }
}
