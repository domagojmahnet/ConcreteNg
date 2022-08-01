import { DiaryFilterColumnsEnum } from "../enums/diary-filter-columns-enum"
import { PricingListFilterColumnsEnum } from "../enums/pricing-list-filter-columns-enum"
import { ProjectFilterColumnsEnum } from "../enums/project-filter-columns-enum"

export interface TableRequest {
    currentPage: number,
    pageSize: number,
    orderBy: string,
    isAscending: boolean,
    filters: BaseFilter[]
}

export interface BaseFilter{
    columnName: ProjectFilterColumnsEnum | PricingListFilterColumnsEnum | DiaryFilterColumnsEnum,
    filterQuery: string
}
