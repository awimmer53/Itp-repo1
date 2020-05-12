using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using static System.Console;

namespace WimmerAddie_GameProject
{
    class Game
    {
        public World MyWorld;
        private Player CurrentPlayer;
        


        public void Start()
        {
            
            Title = "Mouse Maze ~o%";
            CursorVisible = false;
            BackgroundColor = ConsoleColor.Yellow;
            Clear();


            string[,] grid =
            {
                {"*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*"},
                {"*", " ", "*" , " ", " ", " ", " ", " ", " ", " ", "*", " ", " ", " ", " ", " ", " ", "*", " ", "v"},
                {" ", " ", "*" , " ", "*", " ", "*", "*", "*", " ", "*", "*", "*", " ", "*", "*", " ", "*", " ", "*"},
                {"*", " ", "*" , " ", "*", " ", "*", " ", " ", " ", "*", " ", " ", " ", "*", " ", " ", "*", " ", "*"},
                {"*", " ", "*" , " ", "*", " ", " ", " ", "*", " ", "*", " ", "*", "*", "*", " ", "*", "*", " ", "*"},
                {"*", " ", "*" , "*", "*", " ", "*", " ", "*", " ", "*", " ", " ", " ", "*", " ", " ", " ", " ", "*"},
                {"*", " ", " " , " ", " ", " ", "*", " ", "*", " ", "*", "*", "*", " ", "*", " ", "*", "*", "*", "*"},
                {"*", " ", "*" , "*", "*", " ", "*", " ", "*", " ", " ", " ", "*", " ", "*", " ", "*", " ", " ", "V"},
                {"*", " ", "*" , " ", "*", " ", "*", "*", "*", "*", "*", " ", "*", " ", "*", " ", " ", " ", "*", "*"},
                {"*", " ", " " , " ", "*", " ", " ", " ", "*", " ", " ", " ", " ", " ", "*", " ", "*", " ", " ", "*"},
                {"*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*"},

            };

            
            MyWorld = new World(grid);
            CurrentPlayer = new Player(0, 2);
            

            RunGameLoop();
        }

        private void DisplayIntro()
        {
            ForegroundColor = ConsoleColor.Black;
            WriteLine(@" __  __  __  _  _  ___  ___    __  __   __   ___  ___ 
(  \/  )/  \( )( )/ __)(  _)  (  \/  ) (  ) (_  )(  _)
 )    (( () ))()( \__ \ ) _)   )    (  /__\  / /  ) _)
(_/\/\_)\__/ \__/ (___/(___)  (_/\/\_)(_)(_)(___)(___)");
            WriteLine("\n%o~ Welcome to Mouse Maze! ~o%");
            WriteLine("\nHow to Play: ");
            WriteLine("~ Use the arrow keys to scurry around the map to find the delicious cheese.");
            WriteLine("~ End Goal: the yellow V.");
            WriteLine("~ Press any key to start :)");

            ResetColor();
            ReadKey(true);
        }

        public void DisplayOutro()
        {
            Clear();
            ForegroundColor = ConsoleColor.Yellow;
            //source : https://www.asciiart.eu/animals/rodents/mice
            WriteLine(@"         _
       (( )_,     ,
.--.    \ '/     /.\
    )   / \=    /O o\     _
   (   / _/    /' o O| ,_( ))___     (`
    `-|   )_  /o_O_'_(  \'    _ `\    ) 
jgs   `""""`            =`---<_,__/---'
                                   ");

            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine(" YAY! You found the Cheese!");
            WriteLine("Thanks for playing!!");
            WriteLine("Press any key ot exit...");
            ResetColor();
            ReadKey(true);
        }

        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }

        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }

        private void RunGameLoop()
        {
            DisplayIntro();
            while(true)
            {
                DrawFrame();

                HandlePlayerInput();

                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);

                if (elementAtPlayerPos == "V")
                {
                    break;
                }
                
                System.Threading.Thread.Sleep(20);
            }
            DisplayOutro();
        }
    }
}
