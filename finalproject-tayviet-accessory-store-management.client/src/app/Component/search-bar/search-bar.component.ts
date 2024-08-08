import { Component, Output, EventEmitter } from '@angular/core';
import { OutputSearch } from '../../Interface/ioutput-search';
@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrl: './search-bar.component.css'
})
export class SearchBarComponent {
  @Output() searchSubmitEvent = new EventEmitter<OutputSearch>();
  outputSearch: OutputSearch = {
    searchString: '',
    option: [],
  }
  searchSubmit() {
    this.searchSubmitEvent.emit(this.outputSearch);
  }
}
