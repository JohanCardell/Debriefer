using System;
using System.Collections.Generic;
using System.Text;
using Debriefer.Model;
using Debriefer.View;
using System.Linq;

namespace Debriefer.Control
{
    public class Controller
    {
        private ReportsDBContext model;
        public Controller(ReportsDBContext model)
        {
            this.model = model;
        }
        private InfoMessageView welcomeView;
        private NavigationMenuView mainMenuView;
        private LoginView loginView;

        internal void Run()
        {
            GoToWelcomeScreen();
        }

        public void GoToWelcomeScreen()
        {
            if (welcomeView == null) welcomeView = new InfoMessageView
            {
                Message = "Welcome to this app",
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
                        Title = "View reports",
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

        private void GoToLoginScreen()
        {
            loginView = new LoginView { ValidateLogin = ValidateLogin, LoginSuccessCallback = GoToProfile };
            loginView.Display();
        }

        private bool ValidateLogin(string username, string password)
        {
            Player player;
            try
            {
                player = model.Players.Single(p => p.Name == username); 
            }
            catch (Exception ex)
            {
                return false;
            }
            return (player.Password == password);
        }

        private void GoToReports()
        {

        }



        private void GoToProfile()
        {
            //init profile
            //profileView.Display()
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
                Player = player 
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
