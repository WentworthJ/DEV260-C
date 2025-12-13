
Structure	Operation	Big-O (Avg)	One-sentence rationale
Array	Access by index		    O(1) — Constant, because the program knows exactly where to go.
Array	Search (unsorted)		O(n) — Linear, because the lack of being sorted means each item has to be checked.
List<T>	Add at end		        O(1) — Constant, because the program starts at the end, and ads the new value.
List<T>	Insert at index		    O(n) — Linear, because all values at higher indexes have to be shifted one to the right.
Stack<T>	Push / Pop / Peek		    O(1) — Constant, because the program interacts with the last item in all the cases.
Queue<T>	Enqueue / Dequeue / Peek		O(1) — Constant, like with stack, the cases are either interacting with the first value or adding a new value on the end.
Dictionary<K,V>	Add / Lookup / Remove		O(1) — Constant, hte K,V key shows the program where to look.
HashSet<T>	Add / Contains / Remove         O(1) — Constant, the program looks for the specific item, rather than scanning the unncesessary values.