using Client.Models;

namespace Client.Infrastracture;

public class Income : Type
{
    public BudgetModel? Budget;

    public Income()
    {

    }

    public override IncomeModel SetTrackedCategoryOnBudgetAdd(string itemCategory, decimal itemAmount)
    {
        string trackedCategory = $"Tracked{itemCategory}";

        foreach (var category in Budget!.Income!.GetType().GetProperties())
        {
            if (category.Name.Equals(trackedCategory))
            {
                itemAmount += (decimal)category.GetValue(Budget!.Income!, null)!;
                category.SetValue(Budget!.Income!, itemAmount);
            }
        }
        return Budget!.Income!;
    }

    public override IncomeModel SetTrackedCategoryOnBudgetRemove(BudgetTrackedModel model)
    {
        string trackedCategory = $"Tracked{model.Category}";

        foreach (var category in Budget!.Income!.GetType().GetProperties())
        {
            if (category.Name.Equals(trackedCategory))
            {
                var _itemAmount = (decimal)category.GetValue(Budget!.Income!, null)!;
                _itemAmount -= model.Amount;
                category.SetValue(Budget!.Income!, _itemAmount);
            }
        }
        return Budget!.Income!;
    }
}
