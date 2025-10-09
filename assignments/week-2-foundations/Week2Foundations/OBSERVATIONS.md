Showing MEDIAN TIMES
I chose using median times because I felt going with the middlemost option was most likely to be the closest to the average value over time

N = 1000
List.Contains(N-1):   0.432 ms
HashSet.Contains:     0.062 ms
Dict.ContainsKey:     0.036 ms
List.Contains(-1):    0.081 ms
HashSet.Contains(-1): 0.056 ms
Dict.ContainsKey(-1): 0.053 ms

N = 10000
List.Contains(N-1):   0.003 ms
HashSet.Contains:     0.001 ms
Dict.ContainsKey:     0.001 ms
List.Contains(-1):    0.004 ms
HashSet.Contains(-1): 0.001 ms
Dict.ContainsKey(-1): 0.001 ms

N = 100000
List.Contains(N-1):   0.029 ms
HashSet.Contains:     0.001 ms
Dict.ContainsKey:     0.001 ms
List.Contains(-1):    0.013 ms
HashSet.Contains(-1): 0.002 ms
Dict.ContainsKey(-1): 0.003 ms



My predictions seemed to generally be accurate, but a suprise was that List.Contains was higher at N = 100000 than it was at N = 10000.
Every other number was lower, or the same except that one. 