import { Field } from "./FieldModel";
import { Language } from "./LanguageModel";

export class User{
  Id?: number;
  FirstName?: string;
  LastName?:string;
  Email?:string;
  Password?: string;
  ConfirmPassword?:string;
  Languages?: Language[];
  Fields?: Field[];
}
