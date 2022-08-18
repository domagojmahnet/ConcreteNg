import { Component, OnInit, ViewChild } from '@angular/core';
import { DialogPosition, MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { AccountService } from '../../../account.service';
import { UserListFilterEnum } from '../../../enums/user-list-filter-enum';
import { UserTypeEnum } from '../../../enums/user-type';
import { BaseFilter, TableRequest } from '../../../models/table-request';
import { TableResponse } from '../../../models/table-response';
import { User } from '../../../models/user';
import { EmployerService } from '../../employer-service.service';
import { AddEditUserComponent } from '../add-edit-user/add-edit-user.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.less']
})
export class UserListComponent implements OnInit {

    isLoading: boolean;
    dataSource: MatTableDataSource<User> = new MatTableDataSource();
    
    pageSize: number;
    currentPage: number;
    sortByColumn: string;
    isAscending: boolean;
    userListFilterColumnsEnum = UserListFilterEnum;
    userRole: UserTypeEnum;

    get typeEnum(): typeof UserTypeEnum {
        return UserTypeEnum; 
    }
    
    displayedColumns: string[] = [
        "firstName",
        "lastName",
        "username",
        "phone",
        "hireDate",
        "userType",
        "settings"
    ];

    displayedColumnFilters: string[] = [
        "firstName-filter",
        "lastName-filter",
        "username-filter",
        "phone-filter",
        "hireDate-filter",
        "userType-filter",
        "settings-placeholder"
    ];

    filters: BaseFilter[] = [
        {columnName: UserListFilterEnum.FirstName, filterQuery: ""},
        {columnName: UserListFilterEnum.LastName, filterQuery: ""},
        {columnName: UserListFilterEnum.Username, filterQuery: ""},
        {columnName: UserListFilterEnum.Phone, filterQuery: ""},
        {columnName: UserListFilterEnum.HireDate, filterQuery: ""},
        {columnName: UserListFilterEnum.UserType, filterQuery: ""},
    ];

    defaultOrderColumn: string = "pricingListItemName";

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(
        private employerService: EmployerService,
        public dialog: MatDialog,
        private accountService: AccountService) { }

    ngOnInit(): void {
        this.userRole = this.accountService.userValue?.userType;
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

        this.employerService.getUsersTable(tableRequest).subscribe((response: TableResponse) => {
            this.dataSource.data = response.data;
            debugger
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

    keyup(event: KeyboardEvent, columnName: UserListFilterEnum) {
        let filter = this.filters.find(f => f.columnName === columnName);
        if (filter) {
            filter.filterQuery = (event.target as HTMLInputElement).value;
        }
        this.loadData();
    }

    OpenAddEditItemDialog(user?: User){
        const dialogPosition: DialogPosition = {
            right: 0 + 'px',
          }
          
        const dialogRef = this.dialog.open(AddEditUserComponent, {
            width: '450px',
            height: '100%',
            position: dialogPosition,
            data: {user: user}
        });

        dialogRef.afterClosed().subscribe(result => {
            if(result){
                this.loadData();
            }
        });
    }

    deleteItem(id: number){
        this.employerService.deleteEmployee(id).subscribe(() => {
            this.loadData();
        })
    }

}
