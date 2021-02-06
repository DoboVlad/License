import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Field } from 'src/app/Models/FieldModel';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {

  constructor(private http: HttpClient) { }


}
