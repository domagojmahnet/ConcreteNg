import { ExpenseTypeEnum } from "../enums/expense-type-enum";
import { ProjectTaskItem } from "./project-task";

export interface Expense {
    expenseId: number | null;
    quantity?: number;
    projectTaskItem?: ProjectTaskItem;
    totalCost?: number;
    expenseType: ExpenseTypeEnum,
}