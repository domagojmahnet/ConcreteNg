import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { UserTypeEnum } from '../../../enums/user-type';
import { User } from '../../../models/user';
import { EmployerService } from '../../employer-service.service';

@Component({
  selector: 'app-add-edit-user',
  templateUrl: './add-edit-user.component.html',
  styleUrls: ['./add-edit-user.component.less']
})
export class AddEditUserComponent implements OnInit {

    options: UserTypeEnum[] = [
        UserTypeEnum.Administrator,
        UserTypeEnum.Manager
    ];
    get typeEnum(): typeof UserTypeEnum {
        return UserTypeEnum; 
    }
    
    form = this.formBuilder.group({
        firstName: [],
        lastName: [],
        username: [],
        password: [],
        phone: [],
        userType: []
    });

    constructor(
        @Optional() @Inject(MAT_DIALOG_DATA) public data: {user: User, isBuyerAccount: boolean},
        private dialogRef: MatDialogRef<AddEditUserComponent>,
        private formBuilder: FormBuilder,
        private employerService: EmployerService,
        private toastr: ToastrService
    ) { }

    ngOnInit(): void {
        if(this.data){
            this.form = this.formBuilder.group({
                firstName: [this.data.user.firstName],
                lastName: [this.data.user.lastName],
                username: [this.data.user.username],
                password: [this.data.user.password],
                phone: [this.data.user.phone],
                userType: [this.data.user.userType],
            });
        }
    }

    saveChanges(){
        let user: User = {
            userId: this.data.user === undefined ? -1 : this.data.user.userId,
            firstName: this.form.get("firstName")?.value,
            lastName: this.form.get("lastName")?.value,
            username: this.form.get("username")?.value,
            password: this.form.get("password")?.value,
            phone: this.form.get("phone")?.value,
            userType: this.data.isBuyerAccount === true ? UserTypeEnum.Buyer : this.form.get("userType")?.value,
            hireDate: new Date(),
            isActive: true
        }
        this.employerService.createOrUpdateUser(user).subscribe({
            next: (res: any) =>{
                this.dialogRef.close(res)
            },
            error: err => {
                debugger;
                this.toastr.error(err.error, "",{
                    positionClass: 'toast-top-full-width'
                })
            },
        })
    }
}
