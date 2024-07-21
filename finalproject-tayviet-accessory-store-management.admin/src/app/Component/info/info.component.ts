import { Component, Input, Output, EventEmitter, SimpleChanges, OnInit, OnChanges, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IAccount, Account } from '../../Interface/iaccount';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrl: './info.component.css'
})
export class InfoComponent implements OnChanges, OnInit {
  @Input() mode: string = 'view';
  @Input() object: any;
  @ViewChild('fileInput') fileInput!: ElementRef;
  @Output() returnData = new EventEmitter<any>();

  getInfo() {
    this.returnData.emit(this.object);
  }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.readDataAttributes();
    this.getStateOptions();
  }

  openFileInput() {
    this.fileInput.nativeElement.click();
  }

  handleFileInput(fileInput: any) {
    const reader = new FileReader();

    reader.onload = () => {
      this.object.image = reader.result;
    };

    const file = fileInput.files[0];

    if (file) {
      reader.readAsDataURL(file); // Read the file as a Data URL
    }
  }

  attributes: string[] = [];

  readDataAttributes() {
    for (const key in this.object) {
      if (this.object.hasOwnProperty(key) && !this.attributes.includes(key)) {
        this.attributes.push(key);
      }
    }
  }

  invalidAttributes: string[] = [];

  handleInvalidAttributes(invalidAttribute: string[]) {
    this.invalidAttributes = invalidAttribute;
  }

  checkValidAttribute(attribute: string) {
    if (this.invalidAttributes.includes(attribute)) {
      return false;
    } else {
      return true;
    }

  }
  stateOptions: string[] = [];
  getStateOptions() {
    // Get the property names of the target class
    const accountProps = new Account();
    // Check if the object has all the target class properties
    for (const key in this.attributes) {
      if (accountProps.hasOwnProperty('name')) {
        this.stateOptions = ['Active', 'Inactive', 'Locked', 'Unlocked'];
      }
    }
  }
}
