using Webmarket.BussinessLogic.Interfaces;

namespace Webmarket.BussinessLogic
{
    public class BussinesLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}
