import { ProjectStatusEnum } from "../enums/project-status";

export interface ProjectTask {
    projectTaskId: number;
    projectTaskName: string;
    projectTaskItems: ProjectTaskItem[];
}

export interface ProjectTaskItem {
    projectTaskItemId: number;
    projectTaskItemName: string;
    taskItemStatus: ProjectStatusEnum;
    startTime?: Date;
    finishTime?: Date;
}