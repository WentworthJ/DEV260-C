using System;

namespace Week3ArraysSorting
{
    /// <summary>
    /// Board Game implementation for Assignment 2 Part A
    /// Demonstrates multi-dimensional arrays with interactive gameplay
    /// 
    /// Learning Focus: 
    /// - Multi-dimensional array manipulation (char[,])
    /// - Console rendering and user input
    /// - Game state management and win detection
    /// 
    /// Choose ONE game to implement:
    /// - Tic-Tac-Toe (3x3 grid)
    /// - Connect Four (6x7 grid with gravity)
    /// - Or something else creative using a 2D array! (I need to be able to understand the rules from your instructions)
    /// </summary>
    public class BoardGame
    {
        // Choose your game and declare the appropriate board
        // Option 2: Connect Four  
         private char[,] board = new char[6, 7]; // 6 rows, 7 columns
        
        // Add fields for game state
         private char currentPlayer = 'X';
         private bool gameOver = false;
         private string winner = "";

        /// <summary>
        /// Constructor - Initialize the board game
        /// Set up your chosen game
        /// </summary>
        public BoardGame()
        {
            // Initialize your board array

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = '.';
                }
            }

            Console.WriteLine("BoardGame constructor - Initialize your chosen game");
        }
        
        /// <summary>
        /// Main game loop - handles the complete game session
        /// Implement the full game experience
        /// </summary>
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("=== BOARD GAME (Part A) ===");
            Console.WriteLine();
            
            // Display game instructions
            DisplayInstructions();
            
            // Implement main game loop
            bool playAgain = true;
            
            while (playAgain)
            {
                // Reset game state for new game
                InitializeNewGame();
                
                // Play one complete game
                PlayOneGame();
                
                // Ask if player wants to play again
                playAgain = AskPlayAgain();
            }
            
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }
        
        /// <summary>
        /// Display game instructions and controls
        /// Customize for your chosen game
        /// </summary>
        private void DisplayInstructions()
        {
            Console.WriteLine("Instructions for game");
            Console.WriteLine();
            
            // Example for Tic-Tac-Toe:
            // Console.WriteLine("TIC-TAC-TOE RULES:");
            // Console.WriteLine("- Players take turns placing X and O");
            // Console.WriteLine("- Enter row and column (0-2) when prompted");
            // Console.WriteLine("- First to get 3 in a row wins!");
            
            // Example for Connect Four:
             Console.WriteLine("CONNECT FOUR RULES:");
             Console.WriteLine("- Players take turns dropping tokens");
             Console.WriteLine("- Enter column number (0-6) when prompted");
             Console.WriteLine("- First to get 4 in a row wins!");
            
            Console.WriteLine();
        }
        
        /// <summary>
        /// Initialize/reset the game for a new round
        /// Reset board and game state
        /// </summary>
        private void InitializeNewGame()
        {
            // Clear the board array
            // Reset current player to 'X'
            // Reset game over flag
            // Clear winner

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = '.';
                }
            }

            currentPlayer = 'X';
            gameOver = false;
            winner = "";
            
            Console.WriteLine("Initialize new game state");
        }
        
        /// <summary>
        /// Play one complete game until win/draw/quit
        /// Implement the core game loop
        /// </summary>
        private void PlayOneGame()
        {
            // Game loop structure:
            while (!gameOver)
            {
                RenderBoard();
                GetPlayerMove();
                CheckWinCondition();
                if (!gameOver)
                {
                    SwitchPlayer();
                }
            }

            RenderBoard();

            if (winner != "")
            {
                Console.WriteLine($"Player {winner} wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            
            //Console.WriteLine("Implement main game loop");
            //Console.WriteLine("This should include:");
            //Console.WriteLine("1. Render board to console");
            //Console.WriteLine("2. Get and validate player input");
            //Console.WriteLine("3. Update board with move");
            //Console.WriteLine("4. Check for win/draw conditions");
            //Console.WriteLine("5. Switch to next player");
        }
        
        /// <summary>
        /// Render the current board state to console
        /// Create clear, readable board display
        /// </summary>
        private void RenderBoard()
        {
            // Display your multi-dimensional array as a visual board
            // Requirements:
            // - Clear, human-readable format
            // - Show current board state
            // - Include row/column labels for easy reference

            Console.WriteLine();
            Console.Write("  ");
            for (int col = 0; col < board.GetLength(1); col++)
            {
                Console.Write($"{col} ");
            }
            Console.WriteLine();

            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.Write($"{row} ");
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write($"{board[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            
            //Console.WriteLine("Render board array to console");
        }
        
        /// <summary>
        /// Get and validate player move input
        /// Handle user input with validation
        /// </summary>
        private void GetPlayerMove()
        {
            // Prompt current player for their move
            // Validate input (in bounds, empty cell, etc.)
            // Keep asking until valid move is entered
            
            Console.WriteLine("Get and validate player move");
            
            // Example input validation structure:
            bool validMove = false;
            while (!validMove)
            {
                Console.Write($"Player {currentPlayer}, enter a column (0-6): ");
                //string input = Console.ReadLine();
                string input;

                while (true)
                {
                    Console.Write("Enter input: ");
                    string? inputRaw = Console.ReadLine();

                    if (inputRaw != null)
                    {
                        input = inputRaw;
                        break;
                    }

                    Console.WriteLine("Input cannot be null. Please try again.");
                }

                //
                int col;
                //     // Parse and validate input
                //     // Set validMove = true when valid move found
                if (int.TryParse(input, out col) && col >= 0 && col < board.GetLength(1))
                {
                    int row = DropToken(col, currentPlayer);
                    if (row != -1)
                    {
                        validMove = true;
                    }
                    else
                    {
                        Console.WriteLine("Column is full. Try another one.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 6.");
                }   
            
            
            }
        }
        
        /// <summary>
        /// Check if current board state has a winner or draw
        /// Implement win detection logic
        /// </summary>
        private void CheckWinCondition()
        {
            // Check for win conditions specific to your game
            
            // For Tic-Tac-Toe:
            // - Check all rows, columns, and diagonals for 3 in a row
            // - Check for draw (board full, no winner)
            
            // For Connect Four:
            // - Check horizontal, vertical, and diagonal lines for 4 in a row
            // - Check for draw (top row full, no winner)

            if (CheckHorizontal(currentPlayer) || CheckVertical(currentPlayer) || CheckDiagonals(currentPlayer))
            {
                gameOver = true;
                winner = currentPlayer.ToString();
            }
            else if (IsBoardFull())
            {
                gameOver = true;
                winner = "";
            }
            
            //Console.WriteLine("Implement win/draw detection");
        }
        
        /// <summary>
        /// Ask player if they want to play another game
        /// Simple yes/no prompt with validation
        /// </summary>
        private bool AskPlayAgain()
        {
            // Ask user if they want to play again
            // Validate input (y/n, yes/no, etc.)
            // Return true for play again, false to return to main menu

            Console.Write("Do you want to play again? (y/n): ");
            //
            //string input = Console.ReadLine().Trim().ToLower();
            string input;
            while (true)
            {
                string? inputRaw = Console.ReadLine();
                if (inputRaw != null)
                {
                    input = inputRaw.Trim().ToLower();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input:");
                }
            }

            //
            return input == "y" || input == "yes";
            
            // Placeholder - always return false for now
            //return false;
        }
        
        /// <summary>
        /// Switch to the next player's turn
        /// Toggle between X and O
        /// </summary>
        private void SwitchPlayer()
        {
            // Switch currentPlayer between 'X' and 'O'  
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';          
            //Console.WriteLine("Switch to next player");
        }
        
        // Add helper methods as needed
        // Examples:
        // - IsValidMove(int row, int col)
        // - IsBoardFull()
        // - CheckRow(int row, char player)
        // - CheckColumn(int col, char player)
        // - CheckDiagonals(char player)
        // - DropToken(int column, char player) // For Connect Four

        private int DropToken(int col, char player)
        {
            for (int row = board.GetLength(0) - 1; row >= 0; row--)
            {
                if (board[row, col] == '.')
                {
                    board[row, col] = player;
                    return row;
                }
            }
            return -1; // Column full
        }

        private bool IsBoardFull()
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[0, col] == '.')
                    return false;
            }
            return true;
        }

        private bool CheckHorizontal(char player)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col <= board.GetLength(1) - 4; col++)
                {
                    if (board[row, col] == player &&
                        board[row, col + 1] == player &&
                        board[row, col + 2] == player &&
                        board[row, col + 3] == player)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

         private bool CheckVertical(char player)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                for (int row = 0; row <= board.GetLength(0) - 4; row++)
                {
                    if (board[row, col] == player &&
                        board[row + 1, col] == player &&
                        board[row + 2, col] == player &&
                        board[row + 3, col] == player)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckDiagonals(char player)
        {
            // Check bottom-left to top-right diagonals (/)
            for (int row = 3; row < board.GetLength(0); row++)
            {
                for (int col = 0; col <= board.GetLength(1) - 4; col++)
                {
                    if (board[row, col] == player &&
                        board[row - 1, col + 1] == player &&
                        board[row - 2, col + 2] == player &&
                        board[row - 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check top-left to bottom-right diagonals (\)
            for (int row = 0; row <= board.GetLength(0) - 4; row++)
            {
                for (int col = 0; col <= board.GetLength(1) - 4; col++)
                {
                    if (board[row, col] == player &&
                        board[row + 1, col + 1] == player &&
                        board[row + 2, col + 2] == player &&
                        board[row + 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}