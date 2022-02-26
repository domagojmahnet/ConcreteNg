import { ProjectStatusEnum } from "../enums/project-status";
import { User } from "./user";

export interface Project {
    projectId: number;
    employer: string;
    name: string;
    epectedStartDate: Date;
    expectedEndDate: Date;
    startDate: Date;
    endDate: Date;
    expectedCost: number;
    currentCost: number;
    projectStatus: ProjectStatusEnum;
    users: User[];
}
