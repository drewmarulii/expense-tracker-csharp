using System;
using System.Collections.Generic;

public class ExpenseTracker
{
    private List<Expense> expenses;
    private List<Expense> dailyExpenses = new List<Expense>();

    private List<Expense> weeklyExpenses = new List<Expense>();

    static int tableWidth = 100;
    public ExpenseTracker(List<Expense> expenses)
    {
        this.expenses = expenses;
    }

    public void AddExpense()
    {
        Expense expense = new Expense();

        Console.WriteLine("\n_________________");
        Console.WriteLine("Add Your Expense:");
        Console.WriteLine("_________________");
        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Amount: Rp ");
        int amount = Convert.ToInt32(Console.ReadLine());

        expense.Description = description;
        expense.Amount = amount;
        expense.Date = DateTime.Now;
        expenses.Add(expense);
        Console.WriteLine("New Expense Has Been Added\n");
        ManageExpenseReport();
    }

    public void DisplayAllExpenses()
    {
        double totalAmount = 0;
        Console.WriteLine("\n_____________________");
        Console.WriteLine("YOUR EXPENSES SUMMARY");
        Console.WriteLine("_____________________");

        PrintLine();
        PrintRow("No.", "Description", "Amount", "Date");
        PrintLine();

        if (expenses.Count > 0)
        {
            for (int i = 0; i < expenses.Count; i++)
            {
                PrintRow((i + 1).ToString(), expenses[i].Description, expenses[i].Amount.ToString(), expenses[i].Date.ToString());
                totalAmount += expenses[i].Amount;
            }
        }
        else
        {
            PrintRow("No Data Found. Try to add expense!");
        }

        PrintLine();
        PrintRow("TotalExpense = Rp " + totalAmount);
        PrintLine();

        Console.WriteLine(" ");
    }

    public void ViewDailySummary()
    {
        double totalAmount = 0;
        Console.Write("\nEnter a date (e.g. 16/10/2023 -> dd/mm/yyyy): ");
        DateTime inputtedDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("\n___________________________");
        Console.WriteLine("YOUR DAILY EXPENSES SUMARRY");
        Console.WriteLine("___________________________");

        PrintLine();
        PrintRow("ID", "Description", "Amount", "Date");
        PrintLine();

        for (int i = 0; i < expenses.Count; i++)
        {
            if (expenses[i].Date.ToShortDateString() == inputtedDate.ToShortDateString())
            {
                dailyExpenses.Add(expenses[i]);
            }
        }

        if (dailyExpenses.Count > 0)
        {
            for (int i = 0; i < dailyExpenses.Count; i++)
            {
                PrintRow((i + 1).ToString(), dailyExpenses[i].Description, dailyExpenses[i].Amount.ToString(), dailyExpenses[i].Date.ToString());
                totalAmount += dailyExpenses[i].Amount;
            }
        }
        else
        {
            PrintRow("No Data Found. Try another date!");
        }

        PrintLine();
        PrintRow("TotalExpense Per" + inputtedDate.ToShortDateString() + " = Rp " + totalAmount);
        PrintLine();
    }

    public void ViewWeeklySummary()
    {
        double totalAmount = 0;
        Console.Write("\nEnter a Start date (e.g. 16/10/2023 -> dd/mm/yyyy): ");
        DateTime startDate = DateTime.Parse(Console.ReadLine());
        DateTime endDate = startDate.AddDays(6);

        Console.WriteLine("\n____________________________");
        Console.WriteLine("YOUR WEEKLY EXPENSES SUMARRY");
        Console.WriteLine("____________________________");

        PrintLine();
        PrintRow("No.", "Description", "Amount", "Date");
        PrintLine();

        for (int i = 0; i < expenses.Count; i++)
        {
            if (expenses[i].Date >= startDate || expenses[i].Date <= endDate)
            {
                weeklyExpenses.Add(expenses[i]);
            }
        }

        if (weeklyExpenses.Count > 0)
        {
            for (int i = 0; i < weeklyExpenses.Count; i++)
            {
                PrintRow((i + 1).ToString(), weeklyExpenses[i].Description, weeklyExpenses[i].Amount.ToString(), weeklyExpenses[i].Date.ToString());
                totalAmount += weeklyExpenses[i].Amount;
            }
        }
        else
        {
            PrintRow("No Data Found. Try another week!");
        }

        PrintLine();
        PrintRow("TotalExpense From: " + startDate.ToShortDateString() + " To: " + endDate.ToShortDateString() + " = Rp " + totalAmount);
        PrintLine();
    }

    public void ManageExpenseReport()
    {
        DisplayAllExpenses();

        Console.WriteLine("Manage Expense Report: ");
        Console.WriteLine("PRESS 1) Add Expense");
        Console.WriteLine("PRESS 2) Edit Expense");
        Console.WriteLine("PRESS 3) Delete Expense");
        Console.WriteLine("PRESS 4) Main Menu");
        Console.Write("Input Option: ");
        int option = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("");

        switch (option)
        {
            case 1:
                AddExpense();
                break;
            case 2:
                EditExpense();
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
    }

    private void EditExpense()
    {
        Console.WriteLine("____________");
        Console.WriteLine("Edit Expense");
        Console.WriteLine("*PRESS ENTER IF NOT CHANGES NEEDED*");
        Console.WriteLine("____________");

        Console.Write("Choose ID Expense: ");
        int option = Convert.ToInt32(Console.ReadLine());
        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Amount: Rp ");
        int amount = Convert.ToInt32(Console.ReadLine());

        if (!string.IsNullOrEmpty(description))
        {
            expenses[option - 1].Description = description;
        }

        expenses[option - 1].Amount = amount;

        expenses[option - 1].Date = DateTime.Now;

        Console.WriteLine("\nExpense Has Been Edited");
        ManageExpenseReport();
    }

    static void PrintLine()
    {
        Console.WriteLine(new string('-', tableWidth));
    }

    static void PrintRow(params string[] columns)
    {
        int width = (tableWidth - columns.Length) / columns.Length;
        string row = "|";

        foreach (string column in columns)
        {
            row += AlignCenter(column, width) + "|";
        }

        Console.WriteLine(row);
    }

    static string AlignCenter(string text, int width)
    {
        text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

        if (string.IsNullOrEmpty(text))
        {
            return new string(' ', width);
        }
        else
        {
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}