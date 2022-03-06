import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Project } from '../../../models/project';
import { ProjectService } from '../services/project.service';
import { Router } from '@angular/router';
import { TableRequest } from '../../../models/table-request';
import { TableResponse } from '../../../models/table-response';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.less']
})
export class ProjectListComponent implements OnInit {

    isLoading:boolean = true;

    displayedColumns = ['projectId', 'name', 'expectedEndDate', 'expectedCost'];
    dataSource: MatTableDataSource<Project> = new MatTableDataSource();
    pageSize: number = 10;
    currentPage: number = 0;
    sortByColumn = this.displayedColumns[1];

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

        let tableRequest: TableRequest = {
            currentPage: this.currentPage,
            pageSize: this.pageSize,
            orderBy: this.sortByColumn
        }

        this.projectService.getProjectsTable(tableRequest).subscribe((response: TableResponse) => {
            this.dataSource.data = response.data
            setTimeout(() => {
                this.paginator.pageIndex = this.currentPage;
                this.paginator.length = response.totalRows;
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
