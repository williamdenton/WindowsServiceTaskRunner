using System;
using System.Threading.Tasks;

namespace WilliamDenton.WindowsServiceTaskDemo
{

    public interface IRepeatableWork
    {
        TimeSpan DoWork();
    }

    /// <summary>
    /// Runs a function over and over until stopped.
    /// Gap between runs is controlled by the retrn value of the previous run.
    /// When stopping it lets the current work loop finish, if between runs it exists immediately.
    /// DoWork must not throw exceptions for service will crash, for retry logic, swallow exception and return appropiate delay time.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LoopRunner
    {
        private System.Threading.CancellationTokenSource _cancellationSource;
        private IRepeatableWork _work;
        private Task _runningTask;


        public LoopRunner(IRepeatableWork work)
        {
            _cancellationSource = new System.Threading.CancellationTokenSource();
            _work = work;
        }


        public void Start()
        {
            _runningTask = Task.Run(async () => { await RunLoop(_cancellationSource.Token); });
        }

        public void Stop()
        {
            _cancellationSource.Cancel();
            _runningTask.Wait();
        }

        private async Task RunLoop(System.Threading.CancellationToken ct)
        {
            Console.WriteLine($"RunTask Thread: {System.Threading.Thread.CurrentThread.ManagedThreadId}");

            TimeSpan delayTime = TimeSpan.FromMilliseconds(0);
            while (true)
            {
                try
                {
                    await Task.Delay(delayTime, ct);
                }
                catch (TaskCanceledException)
                {
                    return;
                }

                delayTime = _work.DoWork();

            }
        }

    }

}
