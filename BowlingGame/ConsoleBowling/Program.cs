using System;
using System.Collections.Generic;
using System.Linq;
using BowlingTests;
using static System.Console;

namespace ConsoleBowling
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            bool error = true;
            
            WriteLine("Type number of players, max 2");
            var numberOfPlayers = 0;
            while (error)
            { 
                try 
                { 
                    numberOfPlayers = Convert.ToInt32(ReadLine());
                    if (numberOfPlayers <= 2 && numberOfPlayers > 0)
                        error = false;
                }
                catch (Exception e)
                {
                    // ignored
                } 
            }

            var gameSetup = new BowlingGameSetup();

            var players = CreatePlayers(numberOfPlayers);

            foreach (var player in players)
            {
                gameSetup.AddPlayer(player);
            }
            
            var turnManager = new PlayerTurnManager(gameSetup.GetPlayers());

            while (!turnManager.GameOver)
            {
                try
                {
                    WriteLine("Write Next Roll");
                    var roll = Convert.ToInt32(ReadLine());
                    turnManager.Roll(roll);
                }
                catch (Exception e)
                {
                    //IGNORE
                }
            }

            var scoreCalculator = new BowlingScoreCalculator();
            
            var scores = players.Select(player => scoreCalculator.GetScore(player.turns)).ToList();

            foreach (var score in scores)
            {
                WriteLine(score);
            }
        }

        private static List<Player> CreatePlayers(int numberOfPlayers)
        {
            var players = new List<Player>();

            while (players.Count < numberOfPlayers)
            {
                try
                {
                    players.Add(PlayerFactory.CreatePlayer(new CreatePlayerDto(ReadLine())));
                }
                catch (Exception e)
                {
                    //Ignore
                }
            }

            return players;
        }
    }
}