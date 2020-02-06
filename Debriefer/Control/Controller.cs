using Debriefer.Model;
using Debriefer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debriefer.Control
{
    public class Controller
    {
        private UserSession userSession;
        private ReportsDBContext context;
        private CreateUserView createUserView;
        private InfoMessageView welcomeView;
        private NavigationMenuView mainMenuView;
        private NavigationMenuView reportsMenuView;
        private LoginView loginView;
        private ReportsView reportsView;
        public Controller(UserSession userSession)
        {
            this.context = userSession.context;
            this.userSession = userSession;
            reportsView = new ReportsView { reports = context.Reports.OrderByDescending(r => r.Date).ToList(), BackToMain = GoToMainMenu };

        }

        internal void Run()
        {
            GenerateMenus();
            GoToWelcomeScreen();
        }

        private void GenerateMenus()
        {
            if (mainMenuView == null) mainMenuView = new NavigationMenuView
            {
                Message = "MainMenu",
                MenuItems = new List<NavigationMenuItemView>
                {
                    new NavigationMenuItemView
                    {
                        Title = "Login",
                        GoTo = GoToLoginScreen
                    },

                    new NavigationMenuItemView
                    {
                        Title = "Reports",
                        GoTo = GoToReportsMenu
                    },
                    new NavigationMenuItemView
                    {
                        Title = "Exit Program",
                        GoTo = ()=>Environment.Exit(0)
                    }
                }
            };
            if (reportsMenuView == null) reportsMenuView = new NavigationMenuView
            {
                Message = "Reports Menu",
                MenuItems = new List<NavigationMenuItemView>
                {
                    new NavigationMenuItemView
                    {
                        Title = "View all reports",
                        GoTo = reportsView.DisplayAllReports
                    },
                    new NavigationMenuItemView
                    {
                        Title = "Go back to main menu",
                        GoTo = GoToMainMenu
                    },
                    new NavigationMenuItemView
                    {
                        Title = "Exit Program",
                        GoTo = ()=>Environment.Exit(0)
                    }
                }
            };

        }

        public void GoToWelcomeScreen()
        {
            if (welcomeView == null) welcomeView = new InfoMessageView
            {
                Message = "Debriefer - The After Action Report tool",
                Callback = GoToMainMenu
            };
            welcomeView.Display();
        }

        private void GoToMainMenu()
        {
            mainMenuView.Display();
        }

        public void GoToReportsMenu()
        {
            reportsMenuView.Display();
        }

        private void GoToLoginScreen()
        {
            loginView = new LoginView { ValidateLogin = ValidateLogin, LoginSuccessCallback = SetCurrentUser };
            loginView.Display();
        }
        private void GoToCreateNewUserView()
        {
            createUserView = new CreateUserView { UserInputCallback = CreateUser };
            createUserView.Display();
        }
        private bool ValidateLogin(string username, string password)
        {
            Player player;
            try
            {
                player = context.Players.Single(p => p.Name == username);
            }
            catch (Exception ex)
            {
                return false;
            }
            return (player.Password == password);
        }
        private void CreateForce(string name, Nation nation, Period period, int points)
        {
            context.Add(new Force
            {
                Name = name,
                Nation = nation,
                Period = period,
                Player = userSession.user,
                Points = points
            });
        }
        private void SetCurrentUser(string userName)
        {
            GiveAccessToCreators(userSession.user = context.Players.Single(p => p.Name == userName));
            Console.Clear();
            Console.WriteLine($"Welcome {userSession.user.Name}. You currently have {userSession.user.Wins} wins!");
            Console.ReadKey(true);
            GoToMainMenu();
        }
        private void GiveAccessToCreators(Player user)
        {
            reportsMenuView.MenuItems.Add(new NavigationMenuItemView { Title = "New report", GoTo = GoToCreateReportView });
            mainMenuView.MenuItems.Add(new NavigationMenuItemView { Title = "New force", GoTo = GoToCreateForceView });
            if (user.Admin) mainMenuView.MenuItems.Add(new NavigationMenuItemView { Title = "New user", GoTo = GoToCreateNewUserView });
        }
        private void GoToCreateForceView()
        {
            throw new NotImplementedException();
        }

        private void GoToCreateReportView()
        {
            throw new NotImplementedException();
        }

        private void CreateUser(string name, string password, bool admin)
        {
            context.Add(new Player { Name = name, Password = password, Admin = admin });
            context.SaveChanges();
            Console.WriteLine($"New player created\n" +
                $"Name = {name}\n" +
                $"Password = {password}\n" +
                $"Admin = {admin}");
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey(true);

            GoToMainMenu();

        }

        private void CreateReport()
        {
            throw new NotImplementedException();
        }

        public void Add(ReportsDBContext context, string name)
        {
            context.Add(new Player
            {
                Name = name
            });
        }
        public void Add(ReportsDBContext context, string name, Nation nation, int points, Player player)
        {
            context.Add(new Force
            {
                Name = name,
                Nation = nation,
                Points = points,
                //Player = player 
            });
        }
        public void Add(ReportsDBContext context, string dateTime, GameOverCause gameOverCause, Scenario scenario, Player winner, int winScore, Force winForce, Player loser, int losingScore, Force losingForce, List<Round> rounds)
        {
            context.Add(new Report
            {
                Date = DateTime.Parse(dateTime),
                GameOverCause = gameOverCause,
                Scenario = scenario,
                WinningPlayer = winner,
                WinScore = winScore,
                WinningForce = winForce,
                LosingPlayer = loser,
                LossScore = losingScore,
                LosingForce = losingForce,
                Rounds = rounds
            });
        }
    }
}
