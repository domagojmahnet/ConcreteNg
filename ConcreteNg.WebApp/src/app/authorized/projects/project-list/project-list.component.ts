import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Project } from '../../../models/project';
import { ProjectService } from '../services/project.service';
import { BaseFilter, TableRequest } from '../../../models/table-request';
import { TableResponse } from '../../../models/table-response';
import { MatSort, Sort } from '@angular/material/sort';
import { ProjectStatusEnum } from '../../../enums/project-status';
import { ProjectFilterColumnsEnum } from '../../../enums/project-filter-columns-enum';
import { DialogPosition, MatDialog } from '@angular/material/dialog';
import { AddEditProjectComponent } from '../add-edit-project/add-edit-project.component';
import { UserTypeEnum } from '../../../enums/user-type';
import { AccountService } from '../../../account.service';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.less']
})
export class ProjectListComponent implements OnInit {

    isLoading: boolean;
    dataSource: MatTableDataSource<Project> = new MatTableDataSource();
    pageSize: number;
    currentPage: number;
    sortByColumn: string;
    isAscending: boolean;
    projectStatusEnum = ProjectStatusEnum;
    projectFilterColumnsEnum = ProjectFilterColumnsEnum;
    userRole: UserTypeEnum | undefined;

    public get userTypeEnum(): typeof UserTypeEnum {
        return UserTypeEnum; 
    }
    displayedColumns: string[] = [
        'projectId', 
        'name',
        'expectedEndDate', 
        'expectedCost',
        'projectStatus'
    ];
    
    displayedColumnFilters: string[] = [
        'projectId-filter',
        'name-filter',
        'expectedEndDate-filter',
        'expectedCost-filter',
        'projectStatus-filter'
    ];

    filters: BaseFilter[] = [
        {columnName: ProjectFilterColumnsEnum.ProjectIdFilter, filterQuery: ""},
        {columnName: ProjectFilterColumnsEnum.NameFilter, filterQuery: ""},
        {columnName: ProjectFilterColumnsEnum.ExpectedEndDateFilter, filterQuery: ""},
        {columnName: ProjectFilterColumnsEnum.ExpectedCostFilter, filterQuery: ""},
        {columnName: ProjectFilterColumnsEnum.ProjectStatusFilter, filterQuery: ""}
    ];

    defaultOrderColumn: string = "name";

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(
        private projectService: ProjectService,
        private accountService: AccountService,
        public dialog: MatDialog) { }

    ngOnInit(): void {
        this.initializeTable();
        this.loadData();
        this.userRole = this.accountService.userValue?.userType;
    }

    ngAfterViewInit() {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }

    initializeTable() {
        this.pageSize = 10;
        this.currentPage = 0;
        this.sortByColumn = this.defaultOrderColumn;
        this.isAscending = true;
    }

    loadData() {
        this.isLoading = true;
        let tableRequest: TableRequest = {
            currentPage: this.currentPage,
            pageSize: this.pageSize,
            orderBy: this.sortByColumn,
            isAscending: this.isAscending,
            filters: this.filters
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

    sortChanged(sortState: Sort) {
        if (sortState.direction) {
            this.sortByColumn = sortState.active;
            this.isAscending = sortState.direction === "asc" ? true : false;
        } else {
            this.sortByColumn = this.defaultOrderColumn;
            this.isAscending = true;
        }
        this.loadData();
    }

    keyup(event: KeyboardEvent, columnName: ProjectFilterColumnsEnum) {
        let filter = this.filters.find(f => f.columnName === columnName);
        if (filter) {
            filter.filterQuery = (event.target as HTMLInputElement).value;
        }
        debugger;
        this.loadData();
    }

    OpenAddEditItemDialog(project?: Project){
        const dialogPosition: DialogPosition = {
            right: 0 + 'px',
          }
          
        const dialogRef = this.dialog.open(AddEditProjectComponent, {
            width: '450px',
            height: '100%',
            position: dialogPosition,
            data: {project: project}
        });

        dialogRef.afterClosed().subscribe(result => {
            if(result){
                this.loadData();
            }
        });
    }

}
