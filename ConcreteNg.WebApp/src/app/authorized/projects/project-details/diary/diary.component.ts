import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { DialogPosition, MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DiaryFilterColumnsEnum } from '../../../../enums/diary-filter-columns-enum';
import { DiaryItem } from '../../../../models/diary-item';
import { Project } from '../../../../models/project';
import { BaseFilter, TableRequest } from '../../../../models/table-request';
import { TableResponse } from '../../../../models/table-response';
import { EmployerService } from '../../../employer-service.service';
import { ProjectService } from '../../services/project.service';

@Component({
  selector: 'app-diary',
  templateUrl: './diary.component.html',
  styleUrls: ['./diary.component.less']
})
export class DiaryComponent implements OnInit {

    @Input() project: Project;
    @Output() projectChange = new EventEmitter<Project>();

    isLoading: boolean;
    dataSource: MatTableDataSource<DiaryItem> = new MatTableDataSource();
    
    pageSize: number;
    currentPage: number;
    sortByColumn: string;
    isAscending: boolean;
    diaryFilterColumnsEnum = DiaryFilterColumnsEnum;

    displayedColumns: string[] = [
        'dateTime', 
        'description'
    ];

    displayedColumnFilters: string[] = [
        'dateTime-filter',
        'description-filter'
    ];

    filters: BaseFilter[] = [
        {columnName: DiaryFilterColumnsEnum.DateTime, filterQuery: ""},
        {columnName: DiaryFilterColumnsEnum.Description, filterQuery: ""}
    ];

    defaultOrderColumn: string = "dateTime";

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(
        private projectService: ProjectService,
        public dialog: MatDialog) { }

    ngOnInit(): void {
        this.initializeTable();
        this.loadData();
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

        this.projectService.getDiaryItems(tableRequest, this.project.projectId).subscribe((response: TableResponse) => {
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

    keyup(event: KeyboardEvent, columnName: DiaryFilterColumnsEnum) {
        let filter = this.filters.find(f => f.columnName === columnName);
        if (filter) {
            filter.filterQuery = (event.target as HTMLInputElement).value;
        }
        this.loadData();
    }

    OpenAddEditItemDialog(diaryItem?: DiaryItem){
        /*const dialogPosition: DialogPosition = {
            right: 0 + 'px',
        }
          
        const dialogRef = this.dialog.open(AddEditPricingListItemComponent, {
            width: '450px',
            height: '100%',
            position: dialogPosition,
            data: {pricingListItem: pricingListItem}
        });

        dialogRef.afterClosed().subscribe(result => {
            if(result){
                this.loadData();
            }
        });*/
    }
}
