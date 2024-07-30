export interface ISelectOption {
  nameOption: string;
  options: string[];
}

export class SelectOption implements ISelectOption {
  nameOption: string = '';
  options: string[] = [];
}
