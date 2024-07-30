
interface IOutputSearchOption {
  nameOption: string;
  optionValue: string;
}

interface IOutputSearch {
  searchString: string;
  option: IOutputSearchOption[];
}

export class OutputSearch implements IOutputSearch {
  searchString: string ='';
  option: IOutputSearchOption[] =[];
}
