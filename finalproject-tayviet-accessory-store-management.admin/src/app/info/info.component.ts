import { Component, Input, Output, EventEmitter, SimpleChanges, OnInit, OnChanges, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IAccount } from '../Interface/iaccount';

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
}
