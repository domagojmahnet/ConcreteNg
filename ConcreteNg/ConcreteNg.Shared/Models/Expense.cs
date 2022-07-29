using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Interfaces;

namespace ConcreteNg.Shared.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public float? Quantity { get; set; }
        public float TotalCost { get; set; }
        public ProjectTaskItem? ProjectTaskItem { get; set; }
        public ExpenseTypeEnum ExpenseType { get; set; }
        public Partner? Partner { get; set; }
    }

    public class ExpenseBuilder : IExpenseBuilder
    {
        private Expense _expense = new Expense();
        public ExpenseBuilder(float cost, ExpenseTypeEnum expenseType)
        {
            _expense.TotalCost = cost;
            _expense.ExpenseType = expenseType;
        }

        public static ExpenseBuilder Init(float cost, ExpenseTypeEnum expenseType)
        {
            return new ExpenseBuilder(cost, expenseType);
        }

        public Expense Build() => _expense;

        public ExpenseBuilder SetPartner(Partner partner)
        {
            _expense.Partner = partner;
            return this;
        }

        public ExpenseBuilder SetQuantity(float quantity)
        {
            _expense.Quantity = quantity;
            return this;
        }

        public ExpenseBuilder SetProjectTaskItem(ProjectTaskItem projectTaskItem)
        {
            _expense.ProjectTaskItem = projectTaskItem;
            return this;
        }
    }
}
