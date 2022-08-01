import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Expense } from '../../../models/expense';
import { Project } from '../../../models/project';
import { ProjectTask, ProjectTaskItem } from '../../../models/project-task';

@Injectable({
  providedIn: 'root'
})
export class ProjectDetailsService {

    @Output() taskChange = new EventEmitter<ProjectTask>();
    @Output() taskItemChange = new EventEmitter<ProjectTaskItem>();
    
    projectTasks: ProjectTask[];

    constructor(private http: HttpClient) {}

    projectApiUrl: string = environment.BASE_URL+ "api/Project";
    projectTaskApiUrl: string = environment.BASE_URL+ "api/ProjectTask";

    getProjectDetails(id: number) {
        return this.http.get<Project>(this.projectApiUrl + "/" + id);
    }

    getProjectTasks(id: number){
        return this.http.get<ProjectTask[]>(this.projectTaskApiUrl + "/" + id).subscribe((res) => {
            this.projectTasks = res;
            this.taskChange.emit();
            this.taskItemChange.emit();
        });
    }

    updateProjectTaskItem(projectTaskItem: ProjectTaskItem){
        return this.http.post<ProjectTask>(this.projectTaskApiUrl + "/updateItem", projectTaskItem);
    }

    deleteProjectTaskItem(itemId: number, taskId: number){
        return this.http.delete<any>(this.projectTaskApiUrl + "/deleteTaskItem/" + itemId).subscribe((res) => {
            let index = this.projectTasks.findIndex(x => x.projectTaskId == taskId);
            let itemIndex = this.projectTasks[index].projectTaskItems.findIndex(x => x.projectTaskItemId === itemId);
            this.projectTasks[index].projectTaskItems.splice(itemIndex, 1);
            this.taskChange.emit();
        });
    }

    createOrUpdateProjectTask(task: ProjectTask, projectId: number){
        this.http.post<ProjectTask>(this.projectTaskApiUrl + "/projectTask/" + projectId, task).subscribe((res) => {
            if(this.projectTasks.filter(x => x.projectTaskId == task.projectTaskId).length > 0){
                let index = this.projectTasks.findIndex(x => x.projectTaskId == task.projectTaskId);
                this.projectTasks[index] = res;
            } else{
                this.projectTasks.push(res);
            }
            this.taskChange.emit();
        });
    }

    deleteProjectTask(id: number){
        return this.http.delete<any>(this.projectTaskApiUrl + "/deleteTask/" + id).subscribe((res) => {
            let index = this.projectTasks.findIndex(x => x.projectTaskId == id);
            this.projectTasks.splice(index, 1);
            this.taskChange.emit();
        });
    }

    createOrUpdateProjectTaskItem(taskItem: ProjectTaskItem, taskId: number){
        return this.http.post<ProjectTaskItem>(this.projectTaskApiUrl + "/projectTaskItem/" + taskId, taskItem).subscribe((res) => {
            let taskIndex = this.projectTasks.findIndex(x => x.projectTaskId == taskId);
            if(this.projectTasks[taskIndex].projectTaskItems !== null){
                if(this.projectTasks[taskIndex].projectTaskItems?.filter(x => x.projectTaskItemId == taskItem.projectTaskItemId).length > 0){
                    let index = this.projectTasks[taskIndex].projectTaskItems.findIndex(x => x.projectTaskItemId == taskItem.projectTaskItemId);
                    this.projectTasks[taskIndex].projectTaskItems[index] = res;
                } else{
                    this.projectTasks[taskIndex].projectTaskItems.push(res);
                }
            } else{
                this.projectTasks[taskIndex].projectTaskItems = [res];
            }
            this.taskChange.emit();
        });
    }

    addExpense(expense: Expense, taskItemId: number, pricingListItemId: number, partnerId = null){
        return this.http.post<Expense>(this.projectTaskApiUrl + "/expense/" + taskItemId + "/" + pricingListItemId + (partnerId !== null ? "/" + partnerId : ""), expense).subscribe((res) =>{

        })
    }
}
