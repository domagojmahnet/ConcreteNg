import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { PricingListItem } from '../models/pricing-list-item';
import { TableRequest } from '../models/table-request';

@Injectable({
    providedIn: 'root'
})
export class EmployerService {

    employerApiUrl: string = environment.BASE_URL+ "api/Employer";

    constructor(
        private http: HttpClient,
    ) { }

    getPricingListItemsTable (tableRequest: TableRequest){
        return this.http.post<any>(this.employerApiUrl + "/pricingListItems/table", tableRequest);
    }

    createOrUpdatePricingListItem(pricingListItem: PricingListItem){
        return this.http.post<any>(this.employerApiUrl + "/pricingListItem", pricingListItem);
    }

    deletePricingListItem(id: number){
        return this.http.delete<any>(this.employerApiUrl + "/pricingListItem/" + id);
    }
}
