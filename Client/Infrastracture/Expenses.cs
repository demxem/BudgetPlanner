using Client.Models;

namespace Client.Infrastracture;

public class Expenses : Type
{
    public BudgetModel? Budget;

    public Expenses()
    {

    }

    public override ExpensesModel SetTrackedCategoryOnBudgetAdd(string itemCategory, decimal itemAmount)
    {
        string trackedCategory = $"Tracked{itemCategory}";

        foreach (var category in Budget!.Expenses!.GetType().GetProperties())
        {
            if (category.Name.Equals(trackedCategory))
            {
                itemAmount += (decimal)category.GetValue(Budget!.Expenses!, null)!;
                category.SetValue(Budget!.Expenses!, itemAmount);
            }
        }
        return Budget!.Expenses!;
    }

    public override ExpensesModel SetTrackedCategoryOnBudgetRemove(BudgetTrackedModel model)
    {
        string trackedCategory = $"Tracked{model.Category}";

        foreach (var category in Budget!.Expenses!.GetType().GetProperties())
        {
            if (category.Name.Equals(trackedCategory))
            {
                var _itemAmount = (decimal)category.GetValue(Budget!.Expenses!, null)!;
                _itemAmount -= model.Amount;
                category.SetValue(Budget!.Expenses!, _itemAmount);
            }
        }
        return Budget!.Expenses!;
    }
}
