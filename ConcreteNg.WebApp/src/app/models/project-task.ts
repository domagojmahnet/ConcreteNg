import { ProjectStatusEnum } from "../enums/project-status";
import { PricingListItem } from "./pricing-list-item";

export interface ProjectTask {
    projectTaskId: number;
    projectTaskName: string;
    projectTaskItems: ProjectTaskItem[];
}

export interface ProjectTaskItem {
    projectTaskItemId: number;
    pricingListItem: PricingListItem;
    taskItemStatus: ProjectStatusEnum;
    quantity?: number;
    expenditure?: number;
    startTime?: Date;
    finishTime?: Date;
}