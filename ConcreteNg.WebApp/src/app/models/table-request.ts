import { ProjectFilterColumnsEnum } from "../enums/project-filter-columns-enum"

export interface TableRequest {
    currentPage: number,
    pageSize: number,
    orderBy: string,
    isAscending: boolean,
    filters: TableColumnFilter[]
}

export interface TableColumnFilter {
    columnName: ProjectFilterColumnsEnum,
    filterQuery: string
}