import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Project } from '../../../models/project';
import { ProjectService } from '../services/project.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.less']
})
export class ProjectListComponent implements OnInit {

    isLoading:boolean = true;

    displayedColumns = ['projectId', 'name', 'expectedEndDate', 'expectedCost'];
    dataSource: MatTableDataSource<Project> = new MatTableDataSource();
    pageSize = 10;
    currentPage = 0;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    constructor(private projectService: ProjectService) { }

    ngAfterViewInit() {
        this.dataSource.paginator = this.paginator;
    }

    ngOnInit(): void {
        this.loadData()
    }

    loadData() {
        this.isLoading = true;
        this.projectService.getProjects().subscribe((data: Project[]) => {
            this.dataSource.data = data
            setTimeout(() => {
                this.paginator.length = 20;
            });
            this.isLoading = false;
        })
    }

    pageChanged(event: PageEvent) {
        this.pageSize = event.pageSize;
        this.currentPage = event.pageIndex;
        this.loadData();
      }
}
