// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//loop sums
int forSum = 0;
for (int i = 0; i< 50; i++)
        {
            forSum = forSum + (2*(i+1));
        }
Console.WriteLine("for loop sum = " + forSum);

int wSum = 0;
int iW = 0;
while (iW <= 100)
{
    wSum = wSum + iW;
    iW = (iW + 2);
}
Console.WriteLine("While loop sum = " + wSum);

int forEachSum = 0;
int[] evens = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64, 66, 68, 70, 72, 74, 76, 78, 80, 82, 84, 86, 88, 90, 92, 94, 96, 98, 100 };
foreach (int i in evens)
{
    forEachSum = forEachSum + i;
} 

Console.WriteLine("foreach loop sum = " + forEachSum);

// mini challenge. All sums should be equal, so any should work.
if (forEachSum > 2000)
{
    Console.WriteLine("if/else mini challenge:");
    Console.WriteLine("That’s a big number!");
}

string bigNumberBool = (forEachSum > 2000) ? "That’s a big number!" : "Not a big number";
Console.WriteLine("ternary ?: operator mini challenge:");
Console.WriteLine(bigNumberBool);


// Letter Grades
int gradeValue = 73;
Console.WriteLine("if/else Grade = " + (GetLetterGradeIfElse(gradeValue)));
GetLetterGradeSwitch(gradeValue);

//Methods

string GetLetterGradeIfElse(int score)
{
    if (score > 89)
    {
        return "A";
    }
    else if (score > 79)
    {
        return "B";
    }
    else if (score > 69)
    {
        return "C";
    }
    else if (score >= 60)
    {
        return "D";
    }
    else
    {
        return "F";
    }
}

void GetLetterGradeSwitch(int score)
{
    switch (score)
    {
        case int s when (s >= 90 && s <= 100):
            Console.WriteLine("Switch Grade = A");
            break;
        case int s when (s >= 80 && s <= 89):
            Console.WriteLine("Switch Grade = B");
            break;
        case int s when (s >= 70 && s <= 79):
            Console.WriteLine("Switch Grade = C");
            break;
        case int s when (s >= 60 && s <= 69):
            Console.WriteLine("Switch Grade = D");
            break;
        case int s when (s < 60):
            Console.WriteLine("Switch Grade = F");
            break;
        default:
        Console.WriteLine("Switch Grade ERROR");
            break;
    }
}