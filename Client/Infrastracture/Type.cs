using Client.Models;

namespace Client.Infrastracture;

public abstract class Type
{
    public abstract object SetTrackedCategoryOnBudgetAdd(string itemCategory, decimal itemAmount);
    public abstract object SetTrackedCategoryOnBudgetRemove(BudgetTrackedModel budget);
}
