namespace Assignment6
{
    /// <summary>
    /// Main matchmaking system managing queues and matches
    /// Students implement the core methods in this class
    /// </summary>
    public class MatchmakingSystem
    {
        // Data structures for managing the matchmaking system
        private Queue<Player> casualQueue = new Queue<Player>();
        private Queue<Player> rankedQueue = new Queue<Player>();
        private Queue<Player> quickPlayQueue = new Queue<Player>();
        private List<Player> allPlayers = new List<Player>();
        private List<Match> matchHistory = new List<Match>();

        // Statistics tracking
        private int totalMatches = 0;
        private DateTime systemStartTime = DateTime.Now;

        /// <summary>
        /// Create a new player and add to the system
        /// </summary>
        public Player CreatePlayer(string username, int skillRating, GameMode preferredMode = GameMode.Casual)
        {
            // Check for duplicate usernames
            if (allPlayers.Any(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Player with username '{username}' already exists");
            }

            var player = new Player(username, skillRating, preferredMode);
            allPlayers.Add(player);
            return player;
        }

        /// <summary>
        /// Get all players in the system
        /// </summary>
        public List<Player> GetAllPlayers() => allPlayers.ToList();

        /// <summary>
        /// Get match history
        /// </summary>
        public List<Match> GetMatchHistory() => matchHistory.ToList();

        /// <summary>
        /// Get system statistics
        /// </summary>
        public string GetSystemStats()
        {
            var uptime = DateTime.Now - systemStartTime;
            var avgMatchQuality = matchHistory.Count > 0 
                ? matchHistory.Average(m => m.SkillDifference) 
                : 0;

            return $"""
                🎮 Matchmaking System Statistics
                ================================
                Total Players: {allPlayers.Count}
                Total Matches: {totalMatches}
                System Uptime: {uptime.ToString("hh\\:mm\\:ss")}
                
                Queue Status:
                - Casual: {casualQueue.Count} players
                - Ranked: {rankedQueue.Count} players  
                - QuickPlay: {quickPlayQueue.Count} players
                
                Match Quality:
                - Average Skill Difference: {avgMatchQuality:F1}
                - Recent Matches: {Math.Min(5, matchHistory.Count)}
                """;
        }

        // ============================================
        // STUDENT IMPLEMENTATION METHODS (TO DO)
        // ============================================

        /// <summary>
        /// TODO: Add a player to the appropriate queue based on game mode
        /// 
        /// Requirements:
        /// - Add player to correct queue (casualQueue, rankedQueue, or quickPlayQueue)
        /// - Call player.JoinQueue() to track queue time
        /// - Handle any validation needed
        /// </summary>
        public void AddToQueue(Player player, GameMode mode)
        {
            // TODO: Implement this method
            // Hint: Use switch statement on mode to select correct queue
            // Don't forget to call player.JoinQueue()!
            //throw new NotImplementedException("AddToQueue method not yet implemented");
            
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            // Avoid duplicates
            if (casualQueue.Contains(player) || rankedQueue.Contains(player) || quickPlayQueue.Contains(player))
                throw new InvalidOperationException($"{player.Username} is already in a queue.");

            var queue = GetQueueByMode(mode);
            queue.Enqueue(player);
            player.JoinQueue();

            Console.WriteLine($"☑️ {player.Username} joined the {mode} queue ({queue.Count} waiting).");
        }

        /// <summary>
        /// TODO: Try to create a match from the specified queue
        /// 
        /// Requirements:
        /// - Return null if not enough players (need at least 2)
        /// - For Casual: Any two players can match (simple FIFO)
        /// - For Ranked: Only players within ±2 skill levels can match
        /// - For QuickPlay: Prefer skill matching, but allow any match if queue > 4 players
        /// - Remove matched players from queue and call LeaveQueue() on them
        /// - Return new Match object if successful
        /// </summary>
        public Match? TryCreateMatch(GameMode mode)
        {
            // TODO: Implement this method
            // Hint: Different logic needed for each mode
            // Remember to check queue count first!
            //throw new NotImplementedException("TryCreateMatch method not yet implemented");

            
            var queue = GetQueueByMode(mode);
            if (queue.Count < 2)
                return null;

            Player p1 = null;
            Player p2 = null;

            switch (mode)
            {
                case GameMode.Casual:
                    // FIFO pairing
                    p1 = queue.Dequeue();
                    p2 = queue.Dequeue();
                    break;

                case GameMode.Ranked:
                    // Find two players within +/-2 skill levels
                    var players = queue.ToList();
                    for (int i = 0; i < players.Count; i++)
                    {
                        for (int j = i + 1; j < players.Count; j++)
                        {
                            if (CanMatchInRanked(players[i], players[j]))
                            {
                                p1 = players[i];
                                p2 = players[j];
                                break;
                            }
                        }
                        if (p1 != null) break;
                    }
                    if (p1 == null) return null;

                    // Remove matched players
                    queue = new Queue<Player>(players.Where(p => p != p1 && p != p2));
                    if (mode == GameMode.Ranked) rankedQueue = queue;
                    break;

                case GameMode.QuickPlay:
                    // picky at first, use skill matching unless queue > 4
                    var qPlayers = queue.ToList();
                    if (qPlayers.Count > 4)
                    {
                        p1 = queue.Dequeue();
                        p2 = queue.Dequeue();
                    }
                    else
                    {
                        for (int i = 0; i < qPlayers.Count; i++)
                        {
                            for (int j = i + 1; j < qPlayers.Count; j++)
                            {
                                if (Math.Abs(qPlayers[i].SkillRating - qPlayers[j].SkillRating) <= 3)
                                {
                                    p1 = qPlayers[i];
                                    p2 = qPlayers[j];
                                    break;
                                }
                            }
                            if (p1 != null) break;
                        }
                        if (p1 == null) return null;

                        queue = new Queue<Player>(qPlayers.Where(p => p != p1 && p != p2));
                        quickPlayQueue = queue;
                    }
                    break;
            }

            p1.LeaveQueue();
            p2.LeaveQueue();

            var match = new Match(p1, p2, mode);
            return match;
        }

        /// <summary>
        /// TODO: Process a match by simulating outcome and updating statistics
        /// 
        /// Requirements:
        /// - Call match.SimulateOutcome() to determine winner
        /// - Add match to matchHistory
        /// - Increment totalMatches counter
        /// - Display match results to console
        /// </summary>
        public void ProcessMatch(Match match)
        {
            // TODO: Implement this method
            // Hint: Very straightforward - simulate, record, display
            //throw new NotImplementedException("ProcessMatch method not yet implemented");
            
            if (match == null) throw new ArgumentNullException(nameof(match));

            match.SimulateOutcome();
            matchHistory.Add(match);
            totalMatches++;

            Console.WriteLine($"\nMatch Complete! ({match.Mode})");
            Console.WriteLine($"Winner: {match.Winner.Username}");
            Console.WriteLine($"Skill: {match.SkillDifference}");
            Console.WriteLine("_______________________________________\n");
        }

        /// <summary>
        /// TODO: Display current status of all queues with formatting
        /// 
        /// Requirements:
        /// - Show header "Current Queue Status"
        /// - For each queue (Casual, Ranked, QuickPlay):
        ///   - Show queue name and player count
        ///   - List players with position numbers and queue times
        ///   - Handle empty queues gracefully
        /// - Use proper formatting and emojis for readability
        /// </summary>
        public void DisplayQueueStatus()
        {
            // TODO: Implement this method
            // Hint: Loop through each queue and display formatted information
            //throw new NotImplementedException("DisplayQueueStatus method not yet implemented");

            Console.WriteLine("\n------------------------------");
            Console.WriteLine(" Current Queue Status");
            Console.WriteLine("------------------------------\n");

            DisplayQueue("Casual", casualQueue);
            DisplayQueue("Ranked", rankedQueue);
            DisplayQueue("QuickPlay", quickPlayQueue);
        }
        
        

        /// <summary>
        /// TODO: Display detailed statistics for a specific player
        /// 
        /// Requirements:
        /// - Use player.ToDetailedString() for basic info
        /// - Add queue status (in queue, estimated wait time)
        /// - Show recent match history for this player (last 3 matches)
        /// - Handle case where player has no matches
        /// </summary>
        public void DisplayPlayerStats(Player player)
        {
            // TODO: Implement this method
            // Hint: Combine player info with match history filtering
            //throw new NotImplementedException("DisplayPlayerStats method not yet implemented");
            
           
            if (player == null) return;

            Console.WriteLine("\n===============================");
            Console.WriteLine($"Player Statistics: {player.Username}");
            Console.WriteLine("===============================");
            Console.WriteLine(player.ToDetailedString());

            // Queue info
            bool inQueue = casualQueue.Contains(player) || rankedQueue.Contains(player) || quickPlayQueue.Contains(player);
            Console.WriteLine($"Queue Status: {(inQueue ? "🟢 In Queue" : "🔴 Not in Queue")}");
            if (inQueue)
            {
                var mode = allPlayers.FirstOrDefault(p => p == player)?.PreferredMode ?? GameMode.Casual;
                Console.WriteLine($"Estimated Wait: {GetQueueEstimate(mode)}");
            }

            // Match history
            var recentMatches = matchHistory
                .Where(m => m.Player1 == player || m.Player2 == player)
                .OrderByDescending(m => m.MatchTime)
                .Take(3)
                .ToList();

            if (recentMatches.Count == 0)
            {
                Console.WriteLine("\nNo recent matches.\n");
            }
            else
            {
                Console.WriteLine("\nRecent Matches:");
                foreach (var match in recentMatches)
                {
                    string result = match.Winner == player ? "Win" : "Loss";
                    var opponent = match.Player1 == player ? match.Player2 : match.Player1;
                    Console.WriteLine($" - vs {opponent.Username} ({match.Mode}) | {result} | Skill Δ: {match.SkillDifference}");
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// TODO: Calculate estimated wait time for a queue
        /// 
        /// Requirements:
        /// - Return "No wait" if queue has 2+ players
        /// - Return "Short wait" if queue has 1 player
        /// - Return "Long wait" if queue is empty
        /// - For Ranked: Consider skill distribution (harder to match = longer wait)
        /// </summary>
        public string GetQueueEstimate(GameMode mode)
        {
            // TODO: Implement this method
            // Hint: Check queue counts and apply mode-specific logic
            //throw new NotImplementedException("GetQueueEstimate method not yet implemented");
            
            var queue = GetQueueByMode(mode);
            switch (mode)
            {
                case GameMode.Ranked:
                    if (queue.Count >= 2)
                        return "No wait";
                    if (queue.Count == 1)
                        return "Likely long wait (skill-based)";
                    return "Empty queue (no matches soon)";
                default:
                    if (queue.Count >= 2) return "No wait";
                    if (queue.Count == 1) return "Short wait";
                    return "Long wait (empty queue)";
            }
        }

        // ============================================
        // HELPER METHODS (DisplayQueue is the only one put in after the template)
        // ============================================


        //helper method for DisplayQueueStatus
        private void DisplayQueue(string name, Queue<Player> queue)
        {
            Console.WriteLine($"{name} Queue ({queue.Count} players)");

            if (queue.Count == 0)
            {
                Console.WriteLine("   [Empty]\n");
                return;
            }

            int pos = 1;
            foreach (var player in queue)
            {
                var wait = (DateTime.Now - player.JoinedQueue).TotalSeconds;
                Console.WriteLine($"   {pos}. {player.Username,-12} | Skill: {player.SkillRating} | Wait: {wait:F1}s");
                pos++;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Helper: Check if two players can match in Ranked mode (±2 skill levels)
        /// </summary>
        private bool CanMatchInRanked(Player player1, Player player2)
        {
            return Math.Abs(player1.SkillRating - player2.SkillRating) <= 2;
        }

        /// <summary>
        /// Helper: Remove player from all queues (useful for cleanup)
        /// </summary>
        private void RemoveFromAllQueues(Player player)
        {
            // Create temporary lists to avoid modifying collections during iteration
            var casualPlayers = casualQueue.ToList();
            var rankedPlayers = rankedQueue.ToList();
            var quickPlayPlayers = quickPlayQueue.ToList();

            // Clear and rebuild queues without the specified player
            casualQueue.Clear();
            foreach (var p in casualPlayers.Where(p => p != player))
                casualQueue.Enqueue(p);

            rankedQueue.Clear();
            foreach (var p in rankedPlayers.Where(p => p != player))
                rankedQueue.Enqueue(p);

            quickPlayQueue.Clear();
            foreach (var p in quickPlayPlayers.Where(p => p != player))
                quickPlayQueue.Enqueue(p);

            player.LeaveQueue();
        }

        /// <summary>
        /// Helper: Get queue by mode (useful for generic operations)
        /// </summary>
        private Queue<Player> GetQueueByMode(GameMode mode)
        {
            return mode switch
            {
                GameMode.Casual => casualQueue,
                GameMode.Ranked => rankedQueue,
                GameMode.QuickPlay => quickPlayQueue,
                _ => throw new ArgumentException($"Unknown game mode: {mode}")
            };
        }
    }
}