import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/Models/UserModel';
import {AccountService} from '../../Services/AccountService/account.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  constructor(private acount: AccountService){}
  user: User = {};
  registerForm: FormGroup;
  ngOnInit(): void {
    this.registerForm = new FormGroup({
      "FirstName":new FormControl(null, Validators.required),
      "LastName":new FormControl(null, Validators.required),
      "Email": new FormControl(null, [Validators.required, Validators.email]),
      "Password": new FormControl(null, Validators.required),
      "ConfirmPassword": new FormControl(null, Validators.required)
    });
  }

  onSubmit(){
    this.user = {...this.registerForm.value};
    console.log(this.user);
  }
}
