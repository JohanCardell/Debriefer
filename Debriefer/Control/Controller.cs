using Debriefer.Model;
using Debriefer.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Debriefer.Control
{
    public class Controller
    {
        private UserSession userSession;
        private ReportsDBContext context;
        private NewUserDataScreen newUserView;
        private InfoMessageView welcomeView;
        private NavigationMenuView forcesMenuView;
        private NavigationMenuView mainMenuView;
        //TODO private NavigationMenuView playersMenuView;
        private NavigationMenuView reportsMenuView;
        private LoginView loginView;
        private ReportsView reportsView;
        private ForcesView forcesView;

        private List<Player> GetPlayers() { return context.Players.OrderBy(p => p.Name).ToList(); }
        private List<Report> GetReports() { return context.Reports.OrderByDescending(r => r.Date).ToList(); }
        private List<Force> GetForces() { return context.Forces.ToList(); }

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
                reportsView = new ReportsView { GenerateNewReport = AddNewReport, CurrentPlayers = GetPlayers, CurrentReports = GetReports, Callback = GoToReportsMenu };
            }
            if (reportsMenuView == null) reportsMenuView = new NavigationMenuView
            {
                Message = "Reports Menu",
                MenuItems = new List<NavigationMenuItemView>
                {
                    new NavigationMenuItemView
                    {
                        Title = "View all reports",
                        GoTo = GoToViewReportsScreen
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

        private void GoToViewReportsScreen()
        {
            reportsView.DisplayAllReports();
        }

        private void GoToNewUserScreen()
        {
            newUserView = new NewUserDataScreen { UserInputCallback = AddNewUser };
            newUserView.Display();
            GoToMainMenu();
        }

        private void GoToNewReportScreen()
        {
            reportsView.NewReportDataScreen();
        }

        //WIP
        private void GoToPlayersScreen()
        {
            DisplayAllPlayers();
            Console.ReadKey(true);
            GoToMainMenu();
        }
        private void DisplayAllPlayers()
        {
            foreach (var player in GetPlayers())
            {
                Console.WriteLine(player.Name);
            }
        }

        private void GoToForcesMenu()
        {
            if (forcesView == null) forcesView = new ForcesView { CurrentForces = GetForces, GenerateNewForce = AddNewForce, Callback = GoToForcesMenu };
            if (forcesMenuView == null)
            {
                forcesMenuView = new NavigationMenuView
                {
                    Message = "Forces Menu",
                    MenuItems = new List<NavigationMenuItemView>
                    {
                        new NavigationMenuItemView
                        {
                            Title = "Show all forces",
                            GoTo = forcesView.DisplayAll
                        },
                        new NavigationMenuItemView
                        {
                            Title = "Create new force",
                            GoTo = forcesView.NewForceDataScreen
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
            forcesMenuView.Display();
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
            mainMenuView.MenuItems.Insert(2, new NavigationMenuItemView { Title = "Forces", GoTo = GoToForcesMenu });
            if (user.Admin)
            {
                mainMenuView.MenuItems.Insert(3, new NavigationMenuItemView { Title = "New user", GoTo = GoToNewUserScreen });
            }
        }

        private void AddNewUser(string name, string password, bool admin)
        {
            context.Add(new Player { Name = name, Password = password, Admin = admin });
            context.SaveChanges();
        }

        private void AddNewReport(DateTime date, GameOverCause gameOverCause, ScenarioType scenarioType, Player winningPlayer, Force winForce, int winScore, Player losingPlayer, Force losingForce, int lossScore, List<Round> rounds)
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

        private void AddNewForce(string name, Nation nation, Period period, int points)
        {
            context.Add(new Force
            {
                Name = name,
                Nation = nation,
                Period = period,
                Points = points,
                PlayerId = userSession.user.Id
            });
            context.SaveChanges();
        }
    }
}
