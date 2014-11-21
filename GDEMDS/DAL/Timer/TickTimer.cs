using System.Threading;

namespace DAL.Timer
{
    public class FileLoadTimer : ITickTimer
    {
        public event TickTimer TickEvent;
        
        int _tickTime = 0;

        public FileLoadTimer(int tickTime)
        {
            _tickTime = tickTime;
        }

        public void OnTick()
        {
            if (TickEvent != null)
                TickEvent();
        }
        
        public void StartTimer()
        {
            var thread = new Thread(Run);
            thread.Start();
        }
        
        private void Run()
        {
            while (true)
            {
                Thread.Sleep(_tickTime); //seconds
                OnTick();
            }
        }
        
    }
}