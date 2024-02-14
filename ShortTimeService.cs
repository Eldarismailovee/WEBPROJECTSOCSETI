namespace WebApplication1
{
    public class ShortTimeService
    {
        public string GetTime() => DateTime.Now.ToShortTimeString();
    }

}
