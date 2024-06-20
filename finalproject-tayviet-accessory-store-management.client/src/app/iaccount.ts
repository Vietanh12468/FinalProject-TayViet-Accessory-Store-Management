export interface IAccount {
  id: string;
  username: string;
  email: string;
  phone: string;
  password: string;
  bankAccount: string;
  address: string;
  image: string | ArrayBuffer | null;
}
