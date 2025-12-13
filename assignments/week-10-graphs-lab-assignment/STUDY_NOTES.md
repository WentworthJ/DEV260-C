# Assignment 10: Flight Route Network Navigator - Implementation Notes

**Name:** [Your Name]

## Graph Data Structure Understanding

**How adjacency list representation works for flight networks:**
[Explain your understanding of how Dictionary<string, List<Flight>> provides O(1) airport lookups, efficient sparse graph storage, and why this is better than adjacency matrix for flight networks with 16 airports and 52 flights]

Answer:
Using a Dictionary<string, List<Flight>> lets me look up an airport with O(1) speed, and only stores the flights that exist, which can make it more efficient than an adjacency matrix since the network has far fewer flights than possible airport pairings.

**Difference between BFS and Dijkstra's algorithms:**
[Explain when to use BFS (shortest path by hops) vs Dijkstra's (shortest path by cost), and how each algorithm guarantees finding optimal paths]

Answer:
BFS explores layer by layer to find the shortest path by the number of stops, while Dijkstra’s uses a priority queue to always expand the cheapest total-cost path, making it best for weighted graphs like flight prices.

## Challenges and Solutions

**Biggest challenge faced:**
[Describe the most difficult part of the assignment - was it implementing BFS traversal, Dijkstra's priority queue logic, path reconstruction from parent maps, or understanding graph algorithms?]

Answer:
Getting Dijkstra’s relaxation logic and priority queue behavior correct.

**How you solved it:**
[Explain your solution approach and what helped you figure it out - research, drawing graphs on paper, debugging with breakpoints, testing with simple examples, etc.]

Answer:
Looking back at the class videos and asking chat gpt to assist when I couldn't determine errors.

**Most confusing concept:**
[What was hardest to understand about graph traversal, queue/priority queue usage, parent map path reconstruction, or algorithm termination conditions?]

Answer:
The path reconstruction was confusing because the parent map builds the path backward, and it took a bit to understand why it needed to.

## Algorithm Implementation Details

**BFS Implementation (FindRoute and FindShortestRoute):**
[Describe how you implemented the queue-based traversal, visited tracking with HashSet, parent map for path reconstruction, and why BFS guarantees shortest path in unweighted graphs]

Answer:
I used a queue for traversal, a HashSet to avoid revisiting airports, and a parent dictionary to rebuild the route, and BFS guarantees the shortest path because it visits nodes in increasing distance order.

**Dijkstra's Implementation (FindCheapestRoute):**
[Explain how you used PriorityQueue<string, decimal>, implemented the relaxation step, tracked distances, and reconstructed the cheapest path]

Answer:
I stored airports in a PriorityQueue<string, decimal> with their running costs, updated distances during relaxation, and used the parent map to rebuild the cheapest path at the end.

**Path Reconstruction Logic:**
[Describe your approach to building the final route from the parent map, handling the reverse traversal, and ensuring the path goes from origin to destination]

Answer:
I followed the parent links backward from the destination to the origin. I added each airport to a list, and then reversed it so the path is printed in the correct order.

## Code Quality

**What you're most proud of in your implementation:**
[Highlight the best aspect of your code - maybe your clean BFS implementation, efficient Dijkstra's algorithm, well-structured network analysis methods, or thorough error handling]

Answer:
I think most everything is fairly readable

**What you would improve if you had more time:**
[Identify areas for potential improvement - perhaps optimizing priority queue usage, adding more comprehensive error handling, implementing bidirectional search, or adding visualization features]

Answer:
I think the error handling could be improved

## Real-World Applications

**How this relates to actual routing systems:**
[Describe how your implementation connects to real-world systems like Google Flights, Google Maps navigation, social network friend suggestions, or internet packet routing]

Answer:
It's how things like Goodgle Flights and GPS navigation actually determine routes.

**What you learned about graph algorithms:**
[What insights did you gain about graph traversal techniques, the power of BFS and Dijkstra's for different optimization goals, and how adjacency lists make sparse graphs efficient?]

Answer:
I learned how powerful BFS and Dijkstra’s are for different optimization goals, and how adjacency lists make large, sparse networks surprisingly fast to work with.

## Testing and Verification

**Test cases you created:**
[List the specific test scenarios you used - which airport pairs did you test? Did you verify shortest vs cheapest routes differ? How did you test edge cases like disconnected airports or origin=destination?]

Answer:
I tested direct flights, multi-stop BFS routes, cheapest-cost Dijkstra routes, invalid airports

**Interesting findings from testing:**
[Describe any surprising results - routes that took unexpected paths, cost vs stops tradeoffs you discovered, or hub airports you identified]

Answer:
Sometimes the cheapest route had more stops than the shortest route, which makes sense, but I hadn't considered it. Hub airports also frequently showed up.

## Optional Challenge

[If you implemented the optional FindRoutesByCriteria method with DFS and constraints, describe your approach here. If not, write "Not implemented - focused on core requirements"]

Answer:
I implemented it using a DFS helper with constraints on maximum stops and total cost. FindRoutesByCriteria tracks the current path, visited airports, and accumulated cost, adding valid routes to the results list whenever the destination is reached within limits.

## Time Spent

**Total time:** ~10 hours (sort of. Off and on while doing work for other classes)

**Breakdown:**

- Understanding graph concepts and assignment requirements: [1 hour]
- Implementing basic search operations (TODO #1-3): [2 hours]
- Implementing BFS pathfinding (TODO #4-5): [2 hours]
- Implementing Dijkstra's algorithm (TODO #6): [2 hours]
- Implementing network analysis (TODO #8-10): [1.5 hours]
- Testing with flights.csv and edge cases: [0.5 hours]
- Debugging graph traversal algorithms: [1 hours]
- Writing these notes: [40 minutes]

**Most time-consuming part:** [Which aspect took the longest and why - understanding Dijkstra's algorithm, debugging path reconstruction, implementing priority queue logic, etc.]
Dijkstra’s algorithm took the longest because I kept checking the priority queue behavior and verifying the correct path reconstruction.

## Key Takeaways

**Most important lesson learned:**
[What's the single most valuable insight you gained from this assignment about graph algorithms, pathfinding, or algorithm design?]

Answer:
How fundamental graph algorithms are and how they let you solve complex routing problems without too much code.

**How this changed your understanding of data structures:**
[How did working with graphs expand your perspective on data organization compared to arrays, linked lists, trees, etc.?]

Answer:
I realized how flexibly they can be used compared to linear structures, and how good they can be for real life use.