import { ExpenseTypeEnum } from "../enums/expense-type-enum";

export interface Expense {
    expenseId: number | null;
    quantity?: number;
    totalCost?: number;
    expenseType: ExpenseTypeEnum,
}