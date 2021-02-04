import { Component, OnInit } from '@angular/core';
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
  ngOnInit(): void {
    // this.acount.register(this.user);
  }
}
