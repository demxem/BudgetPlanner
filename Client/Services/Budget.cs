namespace Client.Services;

public class Budget
{
    public enum Action
    {
        AddTrackedCategory,
        RemoveTrackedCategory
    }

    private enum Type
    {
        Income,
        Savings,
        Expenses
    }

    public enum Category
    {
        Tracked
    }
}