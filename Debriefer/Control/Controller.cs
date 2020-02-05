using System;
using System.Collections.Generic;
using System.Text;
using Debriefer.Model;
using Debriefer.View;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Debriefer.Control
{
    public class Controller
    {
        private UserSession userSession;
        private ReportsDBContext context;
        private InfoMessageView welcomeView;
        private NavigationMenuView mainMenuView;
        private NavigationMenuView reportsMenuView;
        private LoginView loginView;
        private ReportsView reportsView;
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
                        Title = "Reports",
                        GoTo = GoToReports
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

        public void GoToReportsMenu()
        {
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
            reportsMenuView.Display();
        }

        private void GoToLoginScreen()
        {
            loginView = new LoginView { ValidateLogin = ValidateLogin, LoginSuccessCallback = SetCurrentUser};
            loginView.Display();
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

        private void GoToReports()
        {
            if (reportsView == null)
            {
                Console.WriteLine("Loading reports...");
                reportsView = new ReportsView { reports = context.Reports.OrderByDescending(r => r.Date).ToList(), BackToMain = GoToMainMenu };
                Console.Clear();
            }
            GoToReportsMenu();
        }

        private void CreateForce(string name, Nation nation, Period period, int points)
        {
            context.Add(new Force
            {
                Name = name,
                Nation = nation,
                Period = period,
                Player = userSession.player,
                Points = points
            });
        }


        private void SetCurrentUser(string player)
        {
            userSession.player = context.Players.Single(p => p.Name == player);
            Console.WriteLine($"Welcome {userSession.player.Name}. You currently have {userSession.player.Wins} wins!");
            Console.ReadKey(true);
            GoToMainMenu();
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
