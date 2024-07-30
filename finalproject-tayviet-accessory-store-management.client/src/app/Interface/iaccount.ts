export interface IAccount {
  id: string;
  name: string;
  email: string;
  password: string;
  phoneNumber: string;
  username: string;
  state: string;
  role: string;
  image: string | ArrayBuffer | null;
}

export class Account implements IAccount {
  id: string = "";
  name: string = "";
  email: string = "";
  password: string = "";
  phoneNumber: string = "";
  username: string = "";
  state: string = "";
  role: string = "";
  image: string | ArrayBuffer | null = "";
}
