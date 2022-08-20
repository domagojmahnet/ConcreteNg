import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Partner } from '../../../../models/partner';
import { EmployerService } from '../../../employer-service.service';

@Component({
  selector: 'app-add-edit-partner',
  templateUrl: './add-edit-partner.component.html',
  styleUrls: ['./add-edit-partner.component.less']
})
export class AddEditPartnerComponent implements OnInit {

    form = this.formBuilder.group({
        name: [],
        address: [],
        contactPerson: [],
        contactNumber: [],
    });

    constructor(
        @Optional() @Inject(MAT_DIALOG_DATA) public data: {partner: Partner},
        private dialogRef: MatDialogRef<AddEditPartnerComponent>,
        private formBuilder: FormBuilder,
        private employerService: EmployerService
    ) { }

    ngOnInit(): void {
        if(this.data){
            this.form = this.formBuilder.group({
                name: [this.data.partner.name],
                address: [this.data.partner.address],
                contactPerson: [this.data.partner.contactPerson],
                contactNumber: [this.data.partner.contactNumber]
            });
        }
    }

    saveChanges(){
        let partner: Partner = {
            partnerId: this.data.partner === undefined ? -1 : this.data.partner.partnerId,
            name: this.form.get("name")?.value,
            address: this.form.get("address")?.value,
            contactPerson: this.form.get("contactPerson")?.value,
            contactNumber: this.form.get("contactNumber")?.value,
            isActive: true
        }
        this.employerService.createOrUpdatePartner(partner).subscribe(() => {
            this.dialogRef.close(true);
        })
    }

}
