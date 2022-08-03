import { Component, OnInit, ViewChild } from '@angular/core';
import { DialogPosition, MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PartnerListFilterEnum } from '../../../enums/partner-list-filter-enum';
import { Partner } from '../../../models/partner';
import { BaseFilter, TableRequest } from '../../../models/table-request';
import { TableResponse } from '../../../models/table-response';
import { EmployerService } from '../../employer-service.service';
import { AddEditPartnerComponent } from './add-edit-partner/add-edit-partner.component';

@Component({
  selector: 'app-partner-list',
  templateUrl: './partner-list.component.html',
  styleUrls: ['./partner-list.component.less']
})
export class PartnerListComponent implements OnInit {

    isLoading: boolean;
    dataSource: MatTableDataSource<Partner> = new MatTableDataSource();
    
    pageSize: number;
    currentPage: number;
    sortByColumn: string;
    isAscending: boolean;
    partnerListFilterEnum = PartnerListFilterEnum;

    displayedColumns: string[] = [
        'name', 
        'address',
        'contactPerson',
        'contactNumber',
        'settings'
    ];

    displayedColumnFilters: string[] = [
        'name-filter',
        'address-filter',
        'contactPerson-filter',
        'contactNumber-filter',
        'settings-fillEmptyColumn'
    ];

    filters: BaseFilter[] = [
        {columnName: PartnerListFilterEnum.Name, filterQuery: ""},
        {columnName: PartnerListFilterEnum.Address, filterQuery: ""},
        {columnName: PartnerListFilterEnum.ContactPerson, filterQuery: ""},
        {columnName: PartnerListFilterEnum.ContactNumber, filterQuery: ""}
    ];

    defaultOrderColumn: string = "pricingListItemName";

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(
        private employerService: EmployerService,
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

        this.employerService.getPartnersTable(tableRequest).subscribe((response: TableResponse) => {
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

    keyup(event: KeyboardEvent, columnName: PartnerListFilterEnum) {
        let filter = this.filters.find(f => f.columnName === columnName);
        if (filter) {
            filter.filterQuery = (event.target as HTMLInputElement).value;
        }
        this.loadData();
    }

    OpenAddEditItemDialog(partner?: Partner){
        const dialogPosition: DialogPosition = {
            right: 0 + 'px',
          }
          
        const dialogRef = this.dialog.open(AddEditPartnerComponent, {
            width: '450px',
            height: '100%',
            position: dialogPosition,
            data: {partner: partner}
        });

        dialogRef.afterClosed().subscribe(result => {
            if(result){
                this.loadData();
            }
        });
    }

    deleteItem(id: number){
        this.employerService.deletePartner(id).subscribe(() => {
            this.loadData();
        })
    }

}
