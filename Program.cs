class Program
{
    private static List<Expense> expenses = new List<Expense>();

    static void Main(string[] args)
    {
        MainMenu();
    }

    static void MainMenu()
    {
        ExpenseTracker tracker = new ExpenseTracker(expenses);

        Console.WriteLine("Expense Tracker");
        Console.WriteLine("Press 1) Add Expense");
        Console.WriteLine("Press 2) Show Daily Report");
        Console.WriteLine("Press 3) Show Weekly Report");
        Console.WriteLine("Press 4) Show All Expenses");
        Console.Write("Input Option: ");
        int option = Convert.ToInt16(Console.ReadLine());

        if (option > 0 && option < 5)
        {
            switch (option)
            {
                case 1:
                    tracker.AddExpense();
                    break;
                case 2:
                    tracker.ViewDailySummary();
                    break;
                case 3:
                    Console.WriteLine("\nSorry, Under Development\n");
                    break;
                case 4:
                    tracker.DisplayAllExpenses();
                    break;
                default:
                    break;
            }
        }
        else
        {
            Console.WriteLine("\nUnknown Option, Please Try Again!\n");
        }

        MainMenu();
    }
}
