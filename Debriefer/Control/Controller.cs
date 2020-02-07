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
        private NavigationMenuView forcesMenuView;
        private NavigationMenuView mainMenuView;
        private NavigationMenuView playersMenuView;
        private NavigationMenuView reportsMenuView;
        private LoginView loginView;
        private GetNewReportDataScreen newReportView; 
        private ReportsView reportsView;
        private List<Player> GetPlayers() { return context.Players.OrderByDescending(p => p.Name).ToList(); }
        private List<Report> GetReports() { return context.Reports.OrderByDescending(r => r.Date).ToList(); }
        //private List<Force> GetForces() { return context.Forces.OrderByDescending(f => f.Nation.ToString()).ToList(); }

        public Controller(UserSession userSession)
        {
            this.context = userSession.context;
            this.userSession = userSession;

        }

        internal void Run()
        {
            GoToWelcomeScreen();
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
                        Title = "Exit Program",
                        GoTo = ()=>Environment.Exit(0)
                    }
                }
            };
            mainMenuView.Display();
        }

        private void GoToLoginScreen()
        {
            loginView = new LoginView { ValidateLogin = ValidateLogin, LoginSuccessCallback = SetCurrentUser };
            loginView.Display();
        }

        private void GoToReportsMenu()
        {
            if (reportsView == null)
            {
                reportsView = new ReportsView { CurrentReports = GetReports, Callback = GoToReportsMenu };
            }
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
                        Title = "Create new report",
                        GoTo = GoToNewReportScreen
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
            reportsMenuView.Display();
        }

        private void GoToCreateNewUserScreen()
        {
            createUserView = new CreateUserView { UserInputCallback = AddNewUser };
            createUserView.Display();
        }
       
        private void GoToNewReportScreen()
        {
            if(newReportView == null)
            {
                newReportView = new GetNewReportDataScreen() { ImportCurrentPlayers = GetPlayers, GenerateNewReport = AddNewReport };
            }
            newReportView.Display();
            GoToReportsMenu();
        }
        
        //TODO
        private void GoToPlayersScreen()
        {
            if (playersMenuView == null)
            {
                new NavigationMenuItemView
                {
                    Title = "View all players",
                    //GoTo = reportsView.Disp

                };
            }
        }
        
        //TODO
        private void GoToForcesScreen()
        {
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
        
        private void SetCurrentUser(string userName)
        {
            ExpandMenuOptionsBasedOnRights(userSession.user = context.Players.Single(p => p.Name == userName));
            Console.Clear();
            Console.WriteLine($"Welcome {userSession.user.Name}. You currently have {userSession.user.Wins} wins!");
            Console.ReadKey(true);
            GoToMainMenu();
        }
        
        private void ExpandMenuOptionsBasedOnRights(Player user)
        {
            mainMenuView.MenuItems.RemoveAt(mainMenuView.MenuItems.FindIndex(m => m.Title == "Login"));
            mainMenuView.MenuItems.Insert(0, new NavigationMenuItemView { Title = "Reports", GoTo = GoToReportsMenu });
            mainMenuView.MenuItems.Insert(1, new NavigationMenuItemView { Title = "Players", GoTo = GoToPlayersScreen });
            mainMenuView.MenuItems.Insert(2, new NavigationMenuItemView { Title = "Forces", GoTo = GoToForcesScreen });
            if (user.Admin)
            {
                mainMenuView.MenuItems.Insert(3, new NavigationMenuItemView { Title = "New user", GoTo = GoToCreateNewUserScreen });
            }
        }

        //TODO
        private void DisplayAllPlayers()
        {
            foreach (var player in context.Players)
            {
                Console.WriteLine(player.Name);
            }
            Console.ReadKey(true);
            GoToMainMenu();
        }


        private void AddNewUser(string name, string password, bool admin)
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

        public void AddNewReport(DateTime date, GameOverCause gameOverCause, ScenarioType scenarioType, Player winningPlayer, Force winForce, int winScore, Player losingPlayer, Force losingForce, int lossScore, List<Round> rounds)
        {
            context.Add(new Report
            {
                Date = date,
                GameOverCause = gameOverCause,
                Scenario = context.Scenarios.Single(s => s.ScenarioType == scenarioType),
                WinningPlayer = winningPlayer,
                WinScore = winScore,
                WinningForce = winForce,
                LosingPlayer = losingPlayer,
                LossScore = lossScore,
                LosingForce = losingForce,
                Rounds = rounds
            });
            context.SaveChanges();
        }
       

        //public void Add(ReportsDBContext context, string name, Nation nation, int points, Player player)
        //{
        //    context.Add(new Force
        //    {
        //        Name = name,
        //        Nation = nation,
        //        Points = points,
        //        //Player = player 
        //    });
        //}
    }
}
