import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { SelectOption } from '../../Interface/iselect-option';
import { OutputSearch } from '../../Interface/ioutput-search';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent implements OnInit {
  @Input() selectOptions: SelectOption[] = [];
  @Output() searchSubmitEvent = new EventEmitter<OutputSearch>();

  outputSearch: OutputSearch = {
    searchString: '',
    option: [],
  }

  ngOnInit() {
  }

  setOption(optionValue: string, nameOption: string) {
    const index = this.outputSearch.option.findIndex(o => o.nameOption === nameOption);
    if (index !== -1) {
      this.outputSearch.option[index].optionValue = optionValue;
    }
    else {
      this.outputSearch.option.push({ nameOption: nameOption, optionValue: optionValue });
    }
    console.log(this.outputSearch.option);
  }

  getOptionChoose(nameOption: string) {
    const index = this.outputSearch.option.findIndex(o => o.nameOption === nameOption);
    if (index !== -1) {
      return this.outputSearch.option[index].optionValue;
    }
    return '';
  }

  searchSubmit() {
    this.searchSubmitEvent.emit(this.outputSearch);
  }
}
