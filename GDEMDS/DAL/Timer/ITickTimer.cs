namespace DAL.Timer
{
    public delegate void TickTimer();

    public interface ITickTimer
    {
        event TickTimer TickEvent;
        void OnTick();
        void StartTimer();
    }
}