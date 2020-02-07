using Debriefer.Model;

namespace Debriefer.Control
{
    public class UserSession
    {
        internal ReportsDBContext context;
        internal Controller controller;
        static internal bool UserLoggedIn = false;
        internal Player user;

        public UserSession(ReportsDBContext context)
        {
            this.context = context;
            controller = new Controller(this);
        }
        public void Run() { controller.Run(); }
    }
}
