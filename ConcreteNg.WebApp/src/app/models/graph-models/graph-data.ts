export interface GraphData{
    taskCompletions: TaskCompletion[],
    gaugeData: PieGrid[]
}

export interface TaskCompletion{
    designatedTotal: number;
    pieGrid: PieGrid[]
}

export interface PieGrid{
    name: string,
    value: number
}