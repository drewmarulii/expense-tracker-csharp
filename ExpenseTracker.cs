using System;
using System.Collections.Generic;

public class ExpenseTracker
{
    private List<Expense> expenses;
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
        expense.Date = DateTime.Now.ToString();
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
        } else {
            PrintRow("No Data Found. Try to add expense!");
        }

        PrintLine();
        PrintRow("TotalExpense: Rp " + totalAmount);
        PrintLine();

        Console.WriteLine(" ");
    }

    public void ViewDailySummary(DateTime date)
    {
        double totalAmount = 0;

        for (int i = 0; i < expenses.Count; i++)
        {
            if (DateTime.Parse(expenses[i].Date) == date.Date)
            {
                Console.WriteLine("Description: " + expenses[i].Description + " Amount: " + expenses[i].Amount);
                totalAmount += expenses[i].Amount;
            }
        }

        Console.WriteLine("Total Amount per " + date + ": " + totalAmount);
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