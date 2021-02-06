import { Language } from "./LanguageModel";
import { User } from "./UserModel";

export class Field{
  id?:number;
  name?: string;
  language?: Language[];
  User?: User;
}
