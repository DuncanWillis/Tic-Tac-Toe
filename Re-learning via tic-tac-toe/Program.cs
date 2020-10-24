using System;

namespace Re_learning_via_tic_tac_toe
{
    class Program
    {
        //here we can define our static variables that do not have their own method, but react immediatley within the class program

        static char[,] playField =
        {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'}
        }; //simply a 3x3 matrix of char type entries

        static int turns = 0;

        static void Main(string[] args)
        {
            //set our variables which CAN change within the course of the game
            int player = 2;
            int input = 0;
            bool inputCorrect = false;

            //here we have our 'Main' runthrough of methods
            //this do while(true) loop ensures the game continually runs
            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXorO(player, input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO(player, input);
                }

                SetField();


                //check winning condition
                char[] playerChars = { 'X', 'O' };

                foreach (char playerChar in playerChars)
                {
                    if (((playField[0, 0] == playerChar) && (playField[0, 1] == playerChar) && (playField[0, 2] == playerChar))
                        || ((playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar))
                        || ((playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar))
                        || ((playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar))
                        || ((playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar)))
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("\nPlayer 2 has won");
                        }
                        else
                        {
                            Console.WriteLine("\nPlayer 1 has won");
                        }

                        Console.WriteLine("please enter any key to reset game");
                        Console.ReadKey();
                        resetField();
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("We have a draw");
                        Console.WriteLine("please enter any key to reset game");
                        Console.ReadKey();
                        resetField();
                        break;
                    }

                }

                do //test if field is already taken (and format errors)
                {
                    Console.WriteLine("\nPlayer {0}: Choose your field! ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please only enter numbers!");
                    }

                    if ((input == 1) && (playField[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (playField[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (playField[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (playField[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (playField[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (playField[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (playField[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (playField[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (playField[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\n Input incorrect! Please use another field");
                        inputCorrect = false;
                    }


                } while (inputCorrect == false);

            } while (true);


        }

        //At the bottom of the page, collect all your methods to be used within the program

        //set the field as a static variable
        public static void SetField()
        {
            Console.WriteLine("     |      |      |");
            Console.WriteLine("  {0}  |   {1}  |   {2}  |", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("     |      |      |");
            Console.WriteLine("-------------------|");
            Console.WriteLine("     |      |      |");
            Console.WriteLine("  {0}  |   {1}  |   {2}  |", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("     |      |      |");
            Console.WriteLine("-------------------|");
            Console.WriteLine("     |      |      |");
            Console.WriteLine("  {0}  |   {1}  |   {2}  |", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("     |      |      |");
            turns++; //this adds 1 to the integer turns
        }

        //create a resetField methdo
        public static void resetField()
        {
            char[,] playFieldinitial =
            {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            };

            playField = playFieldinitial;
            SetField();
            turns = 0;
        }

        //based on the user's input and whose turn it is, this is an efficient way to change the entries of the playfield to the apporpriate
        //signs.
        public static void EnterXorO(int player, int input)
        {
            char playerSign = ' ';

            if (player == 1)
            {
                playerSign = 'X';
            }
            else if (player == 2)
            {
                playerSign = 'O';
            }
            switch (input)
            {
                case 1: playField[0, 0] = playerSign; break;
                case 2: playField[0, 1] = playerSign; break;
                case 3: playField[0, 2] = playerSign; break;
                case 4: playField[1, 0] = playerSign; break;
                case 5: playField[1, 1] = playerSign; break;
                case 6: playField[1, 2] = playerSign; break;
                case 7: playField[2, 0] = playerSign; break;
                case 8: playField[2, 1] = playerSign; break;
                case 9: playField[2, 2] = playerSign; break;
            }

        }
    }
}
