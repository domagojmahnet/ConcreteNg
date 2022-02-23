import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent  implements OnInit {

    LoginForm = this.formBuilder.group({
        username: ['', Validators.required],
        password: ['', Validators.required]
    });

    constructor(
        private authService: AuthService,
        private formBuilder: FormBuilder
        ) {
    }



    ngOnInit(): void {
    }

    onSubmit(){
        if (this.LoginForm.invalid) {
            return;
        }
        this.authService.LogUser(this.LoginForm.get("username")?.value, this.LoginForm.get("password")?.value)
    }
}
