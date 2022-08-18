import { Component, OnInit, ViewChild } from '@angular/core';
import { DialogPosition, MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { AccountService } from '../../account.service';
import { PricingListFilterColumnsEnum } from '../../enums/pricing-list-filter-columns-enum';
import { UserListFilterEnum } from '../../enums/user-list-filter-enum';
import { UserTypeEnum } from '../../enums/user-type';
import { PricingListItem } from '../../models/pricing-list-item';
import { BaseFilter, TableRequest } from '../../models/table-request';
import { TableResponse } from '../../models/table-response';
import { EmployerService } from '../employer-service.service';
import { AddEditPricingListItemComponent } from './add-edit-pricing-list-item/add-edit-pricing-list-item.component';

@Component({
  selector: 'app-pricing-list',
  templateUrl: './pricing-list.component.html',
  styleUrls: ['./pricing-list.component.less']
})
export class PricingListComponent implements OnInit {

    isLoading: boolean;
    dataSource: MatTableDataSource<PricingListItem> = new MatTableDataSource();
    
    pageSize: number;
    currentPage: number;
    sortByColumn: string;
    isAscending: boolean;
    pricingListFilterColumnsEnum = PricingListFilterColumnsEnum;
    userRole: UserTypeEnum | undefined;

    public get userTypeEnum(): typeof UserTypeEnum {
        return UserTypeEnum; 
    }

    displayedColumns: string[] = [
        'pricingListItemName', 
        'unitOfMeasurement',
        'price',
        'settings'
    ];

    displayedColumnFilters: string[] = [
        'pricingListItemName-filter',
        'unitOfMeasurement-filter',
        'price-filter'
    ];

    filters: BaseFilter[] = [
        {columnName: PricingListFilterColumnsEnum.PricingListItemName, filterQuery: ""},
        {columnName: PricingListFilterColumnsEnum.UnitOfMeasurement, filterQuery: ""},
        {columnName: PricingListFilterColumnsEnum.Price, filterQuery: ""},
    ];

    defaultOrderColumn: string = "pricingListItemName";

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(
        private employerService: EmployerService,
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

        this.employerService.getPricingListItemsTable(tableRequest).subscribe((response: TableResponse) => {
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

    keyup(event: KeyboardEvent, columnName: PricingListFilterColumnsEnum) {
        let filter = this.filters.find(f => f.columnName === columnName);
        if (filter) {
            filter.filterQuery = (event.target as HTMLInputElement).value;
        }
        this.loadData();
    }

    OpenAddEditItemDialog(pricingListItem?: PricingListItem){
        const dialogPosition: DialogPosition = {
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
        });
    }

    deleteItem(id: number){
        this.employerService.deletePricingListItem(id).subscribe(() => {
            this.loadData();
        })
    }
}
