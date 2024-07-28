import { Component, Input, Output, EventEmitter, SimpleChanges, OnInit, OnChanges, ViewChild, ElementRef } from '@angular/core';
import { IAccount, Account } from '../../Interface/iaccount';
import { Product } from '../../Interface/iproduct';

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

  ignoredAttributes = ['username', 'image', 'state', 'subProductList', 'categoryList', 'orderList', 'description', 'brandID'];

  getInfo() {
    this.returnData.emit(this.object);
  }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.readDataAttributes();
    this.getObjectType()
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
  keyAttributes: string = '';
  stateOptions: string[] = [];
  getObjectType() {
    const accountProps = new Account();
    let isAccount = true;
    const productProps = new Product();
    let isProduct = true;
    for (const key of this.attributes) {
      if (!accountProps.hasOwnProperty(key)) {
        isAccount = false;
        break;
      }
      if (!productProps.hasOwnProperty(key)) {
        isProduct = false;
        break;
      }
    }

    if (isAccount === true) {
      this.stateOptions = ['Active', 'Inactive', 'Locked', 'Unlocked'];
      this.keyAttributes = 'username';
    }
    if (isAccount === true) {
      this.keyAttributes = 'name';
    }
  }
}
