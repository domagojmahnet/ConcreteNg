import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Partner } from '../models/partner';
import { PricingListItem } from '../models/pricing-list-item';
import { TableRequest } from '../models/table-request';
import { User } from '../models/user';

@Injectable({
    providedIn: 'root'
})
export class EmployerService {

    employerApiUrl: string = environment.BASE_URL+ "api/Employer";
    userApiUrl: string = environment.BASE_URL + "api/User";

    constructor(
        private http: HttpClient,
    ) { }

    getPricingListItemsTable(tableRequest: TableRequest){
        return this.http.post<any>(this.employerApiUrl + "/pricingListItems/table", tableRequest);
    }

    getPricingListItems(){
        return this.http.get<PricingListItem[]>(this.employerApiUrl + "/pricingListItems");
    }

    createOrUpdatePricingListItem(pricingListItem: PricingListItem){
        return this.http.post<any>(this.employerApiUrl + "/pricingListItem", pricingListItem);
    }

    deletePricingListItem(id: number){
        return this.http.delete<any>(this.employerApiUrl + "/pricingListItem/" + id);
    }

    getPartners(){
        return this.http.get<Partner[]>(this.employerApiUrl + "/partners");
    }

    getPartnersTable(tableRequest: TableRequest){
        return this.http.post<any>(this.employerApiUrl + "/partners", tableRequest);
    }

    createOrUpdatePartner(partner: Partner){
        return this.http.post<any>(this.employerApiUrl + "/partner", partner);
    }

    deletePartner(id: number){
        return this.http.delete<any>(this.employerApiUrl + "/partner/" + id);
    }

    getUsersTable(tableRequest: TableRequest){
        return this.http.post<any>(this.userApiUrl + "/users", tableRequest);
    }

    createOrUpdateUser(user: User){
        return this.http.post<any>(this.userApiUrl + "/user", user);
    }

    deleteEmployee(id: number){
        return this.http.delete<any>(this.userApiUrl + "/" + id);
    }
}
