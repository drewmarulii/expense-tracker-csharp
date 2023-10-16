using System;
using System.Collections.Generic;

public class ExpenseTracker
{
    private List<Expense> expenses;
    private List<Expense> dailyExpenses = new List<Expense>();

    static int tableWidth = 73;
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
        PrintRow("TotalExpense: Rp " + totalAmount);
        PrintLine();

        Console.WriteLine(" ");
    }

    public void ViewDailySummary()
    {
        double totalAmount = 0;
        Console.Write("\nEnter a date (e.g. 16/10/1987 -> dd/mm/yyyy): ");
        DateTime inputtedDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("\n___________________________");
        Console.WriteLine("YOUR DAILY EXPENSES SUMARRY");
        Console.WriteLine("___________________________");

        PrintLine();
        PrintRow("No.", "Description", "Amount", "Date");
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
        PrintRow("TotalExpense Per" + inputtedDate.ToShortDateString() + ": Rp " + totalAmount);
        PrintLine();
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