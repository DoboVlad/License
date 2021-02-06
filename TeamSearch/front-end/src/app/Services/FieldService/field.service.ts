import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Field } from 'src/app/Models/FieldModel';

@Injectable({
  providedIn: 'root'
})
export class FieldService {
  baseUrl = "https://localhost:5001/fields";
  constructor(private http: HttpClient) { }

  getFields(){
    return this.http.get<Field[]>(this.baseUrl + '/getFields');
  }

  getLanguageByField(id: number){
    return this.http.get<Field>(this.baseUrl + '/fields/' + id);
  }
}
