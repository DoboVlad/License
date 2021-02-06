import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Field } from 'src/app/Models/FieldModel';
import { Language } from 'src/app/Models/LanguageModel';
import { User } from 'src/app/Models/UserModel';
import {AccountService} from '../../Services/AccountService/account.service';
import {FieldService} from '../../Services/FieldService/field.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  constructor(private account: AccountService, private fieldService: FieldService){}
  user: User = {};
  registerForm: FormGroup;
  fields: Field[];
  selectField: number;
  languages: Language[] = [];

  //the languages and fields that are sent to server
  selectedFields: number[] = [];
  selectedLanguage: number[] = [];

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      "FirstName":new FormControl(null, Validators.required),
      "LastName":new FormControl(null, Validators.required),
      "Email": new FormControl(null, [Validators.required, Validators.email]),
      "Password": new FormControl(null, Validators.required),
      "ConfirmPassword": new FormControl(null, Validators.required)
    });

    this.fieldService.getFields().subscribe(fields => {
      this.fields = fields;
    });
  }

  onSubmit(){
    console.log(this.selectedLanguage);
    console.log(this.selectedFields);
    this.user = {...this.registerForm.value};
    console.log(this.user);
  }

  selectedField(event: Event){
    this.selectField = +(<HTMLInputElement>event.target).value;
    //check if the element is checked
    if((<HTMLInputElement>event.target).checked){
      this.selectedFields.push(this.selectField);
      this.fieldService.getLanguageByField(this.selectField).subscribe(languages => {
        this.languages = languages[0].language;
      });
    } else {
      //delete the field from the selectedFields
      var index = this.selectedFields.indexOf(this.selectField);
      this.selectedFields.splice(index, 1);
      var lastElement = this.selectedFields.length-1;
      console.log(this.languages);
      var currentLanguages = [];
      console.log(this.selectField);
      this.fieldService.getLanguageByField(this.selectField).subscribe(languages => {
        currentLanguages = languages[0].language;
        console.log(currentLanguages);

        //get the id's of the current languages
        var keys = [];
        currentLanguages.forEach(el => {
          keys.push(el.id);
        });

        //delete the elements from the selectedLanguage array. If I unchecked a field
        this.selectedLanguage = this.selectedLanguage.filter(element => {
          return !keys.includes(element);
        });

        // get the languages from the last field added
        this.fieldService.getLanguageByField(+this.selectedFields[lastElement]).subscribe(languages => {
          this.languages = languages[0].language;
        });
      });


    }
  }

  selectLanguage(event: Event){
    if((<HTMLInputElement>event.target).checked){
      this.selectedLanguage.push(+(<HTMLInputElement>event.target).value);
    } else {
      var index = this.selectedLanguage.indexOf(+(<HTMLInputElement>event.target).value);
      this.selectedLanguage.splice(index, 1);
    }
  }

}
