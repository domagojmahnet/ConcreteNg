import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
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

    constructor(private http: HttpClient, private toastr: ToastrService) {}

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

    updateProjectTaskItem(projectTaskItem: ProjectTaskItem, projectId: number){
        return this.http.post<ProjectTask>(this.projectTaskApiUrl + "/updateItem/" + projectId, projectTaskItem);
    }

    deleteProjectTaskItem(itemId: number, taskId: number){
        return this.http.delete<any>(this.projectTaskApiUrl + "/deleteTaskItem/" + itemId).subscribe((res) => {
            let index = this.projectTasks.findIndex(x => x.projectTaskId == taskId);
            let itemIndex = this.projectTasks[index].projectTaskItems.findIndex(x => x.projectTaskItemId === itemId);
            this.projectTasks[index].projectTaskItems.splice(itemIndex, 1);
            this.toastr.success("Succesfully deleted task item!", "",{
                positionClass: 'toast-top-full-width'
            });
            this.taskChange.emit();
        });
    }

    createOrUpdateProjectTask(task: ProjectTask, projectId: number){
        return this.http.post<ProjectTask>(this.projectTaskApiUrl + "/projectTask/" + projectId, task);
    }

    handleProjectTaskCreateOrUpdate(task: ProjectTask, res: ProjectTask){
        if(this.projectTasks.filter(x => x.projectTaskId == task.projectTaskId).length > 0){
            let index = this.projectTasks.findIndex(x => x.projectTaskId == task.projectTaskId);
            this.projectTasks[index] = res;
        } else{
            this.projectTasks.push(res);
        }
        this.toastr.success("Succesfully added/edited project task!", "",{
            positionClass: 'toast-top-full-width'
        });
        this.taskChange.emit();
    }


    deleteProjectTask(id: number){
        return this.http.delete<any>(this.projectTaskApiUrl + "/deleteTask/" + id).subscribe((res) => {
            let index = this.projectTasks.findIndex(x => x.projectTaskId == id);
            this.projectTasks.splice(index, 1);
            this.taskChange.emit();
            this.toastr.success("Succesfully deleted project task!", "",{
                positionClass: 'toast-top-full-width'
            });
        });
    }

    createOrUpdateProjectTaskItem(taskItem: ProjectTaskItem, taskId: number){
        return this.http.post<ProjectTaskItem>(this.projectTaskApiUrl + "/projectTaskItem/" + taskId, taskItem)
    }

    handleProjectTaskItemCreateOrUpdate(taskItem: ProjectTaskItem, taskId: number, res: ProjectTaskItem){
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
        this.toastr.success("Succesfully added/edited project task item!", "",{
            positionClass: 'toast-top-full-width'
        });
        this.taskChange.emit();
    }

    addExpense(expense: Expense, taskItemId: number, pricingListItemId: number, partnerId = null){
        return this.http.post<Expense>(this.projectTaskApiUrl + "/expense/" + taskItemId + "/" + pricingListItemId + (partnerId !== null ? "/" + partnerId : ""), expense)
    }

    handleExpenseAddition(res:Expense){
        this.projectTasks.forEach(task => {
            let index = task.projectTaskItems.findIndex(x =>x.projectTaskItemId == res.projectTaskItem?.projectTaskItemId);
            if(index !== -1){
                let totalCost = task.projectTaskItems[index].expenditure ?? 0;
                if(res.totalCost !== undefined){
                    task.projectTaskItems[index].expenditure = totalCost + res.totalCost;
                }
            }
        });
        this.toastr.success("Succesfully added expense!", "",{
            positionClass: 'toast-top-full-width'
        });
    }

    getProjectBuyer(projectId: number){
        return this.http.get<any>(this.projectApiUrl + "/projectBuyer/" + projectId);
    }

    assignBuyerToProject(userId: number, projectId: number){
        return this.http.get<any>(this.projectApiUrl + "/assignBuyer/" + userId + "/" + projectId);
    }
}
