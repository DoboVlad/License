import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {User} from '../../Models/UserModel';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = "https://localhost:5001/";
  constructor(private http: HttpClient) { }

  logIn(creds: {email: string, password: string, ConfirmPassword: string}){
    this.http.post(this.baseUrl + 'login',creds);
  }

  register(user: User){
    this.http.post(this.baseUrl + 'register', user).subscribe(result => {
      console.log(result);

    });
  }
}
