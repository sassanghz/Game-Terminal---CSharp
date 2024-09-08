using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication
{
    internal class VideoGame
    {
        public string name = "Life";
        public int price = 130;
        public static int playerHealth = 100;
        public static int gold = 0;
        public static Random random = new Random();


        public static void intro()
        {
            Console.WriteLine("Welcome to the game of Life! What's your name, adventurer?"); ;
            string playername = Console.ReadLine();
            Console.WriteLine($"Nice to meet you, {playername}! Ready for adventure...(yes/no)");

            string option = Console.ReadLine().ToLower();

            if(option == "yes")
            {
                Console.WriteLine("Let's begin...");
                startGame(playername);
            }
            else
            {
                Console.WriteLine("Maybe next time! Life is waiting...");
                // Exit the program if the player chooses not to play
                Environment.Exit(0);
            }


        }

        public static void startGame(string playername)
        {
            Console.WriteLine($"{playername}, you arrived at the gates of Rey. Turn back or continue your journey:");
            Console.WriteLine("1: Enter the city\n2: Turn back");
            string playerDecision = Console.ReadLine();

            if(playerDecision == "1")
            {
                explore(playername);
            }
            else
            {
                Console.WriteLine("You chose to leave, but destiny awaits those who are brave.");
                Console.WriteLine("Game Over");
                Environment.Exit(0);
            }
        }

        public static void explore(string playername)
        {
            Console.WriteLine("Look out! A creature has just approached you!");

            string[] creatures = { "Goblin", "Ogor", "Troll", "Beast" };
            string creature = creatures[random.Next(creatures.Length)];// choosing a random variable

            Console.WriteLine($"A {creature} has attacked you! Prepare to defend yourself!!!");

            battle(creature);
            checkHealth(playername);

        }

        public static void battle(string creature)
        {
            while(playerHealth > 0)
            {
                Console.WriteLine($"\n{creature} attacks! What will you do?");
                Console.WriteLine("1: Attack\n2: Run");

                string action = Console.ReadLine();

                if(action == "1")
                {
                    int playerDamage = random.Next(10, 25);
                    int enemyDamage = random.Next(5, 20);

                    Console.WriteLine($"You deal {playerDamage} damage to the creature!");
                    Console.WriteLine($"The {creature} hits you back for {enemyDamage} damage.");

                    playerHealth -= enemyDamage;

                    if(random.Next(1,3) == 1)
                    {
                        Console.WriteLine($"You defeated the {creature}! You have collected gold!");
                        int foundGold = random.Next(20, 50);

                        gold += foundGold;

                        Console.WriteLine($"You gained {foundGold} gold. You now have {gold} gold.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("You run away, losing 10 health points in the process.");
                    playerHealth -= 10;
                    break;
                }
                checkHealth("");
            }
        }

        public static void checkHealth(string playername)
        {
            if (playerHealth <= 0)
            {
                Console.WriteLine("\nYou've been defeated... Game Over");
                Environment.Exit(0);
            } else if (playerHealth > 0 && !string.IsNullOrEmpty(playername)){ 
                Console.WriteLine($"You now have {gold} gold. What will you do next?");
                Console.WriteLine("1. Continue exploring\n2. Head back to town");

                string nextAction = Console.ReadLine();

                if (nextAction == "1")
                {
                    exploreForest(playername);
                }
                else
                {
                    Console.WriteLine("You return to town with your loot and rest for the next adventure.");
                }

            }
          
        }

        public static void exploreForest(string playername)
        {
            Console.WriteLine("Done");
        }
    }
}
