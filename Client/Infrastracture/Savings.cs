using Client.Models;

namespace Client.Infrastracture;

public class Savings : Type
{
    public BudgetModel? Budget;

    public Savings()
    {

    }

    public override SavingsModel SetTrackedCategoryOnBudgetAdd(string itemCategory, decimal itemAmount)
    {
        string trackedCategory = $"Tracked{itemCategory}";

        foreach (var category in Budget!.Savings!.GetType().GetProperties())
        {
            if (category.Name.Equals(trackedCategory))
            {
                itemAmount += (decimal)category.GetValue(Budget!.Savings!, null)!;
                category.SetValue(Budget!.Savings!, itemAmount);
            }
        }
        return Budget!.Savings!;
    }

    public override SavingsModel SetTrackedCategoryOnBudgetRemove(BudgetTrackedModel model)
    {
        string trackedCategory = $"Tracked{model.Category}";

        foreach (var category in Budget!.Savings!.GetType().GetProperties())
        {
            if (category.Name.Equals(trackedCategory))
            {
                var _itemAmount = (decimal)category.GetValue(Budget!.Savings!, null)!;
                _itemAmount -= model.Amount;
                category.SetValue(Budget!.Savings!, _itemAmount);
            }
        }
        return Budget!.Savings!;
    }
}
