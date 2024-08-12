import { Component, ViewChild, ElementRef, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { APIService } from '../../Service/API/api.service';
import { AuthenticationService } from '../../Service/Authentication/authentication.service';
import { ICustomer } from '../../Interface/iaccount';

@Component({
  selector: 'app-profile-manager',
  templateUrl: './profile-manager.component.html',
  styleUrl: './profile-manager.component.css'
})
export class ProfileManagerComponent implements OnInit, OnChanges {
  @ViewChild('fileInput') fileInput!: ElementRef;
  view: string = 'profile';
  addressList: string[] = [];
  constructor(private apiService: APIService, private authenticationService: AuthenticationService) {
  }

  ngOnInit(): void {
    this.getUserInfo();
  }

  ngOnChanges(changes: SimpleChanges): void {
  }
  
  onCancel(): void {
    this.getUserInfo();
    this.mode = 'view';
  }

  onSave(): void {
    this.userInfo.addressList = this.addressList;
    this.apiService.changeDetailObject('Customer', this.userInfo).subscribe(
      (result) => {
        this.getUserInfo();
        this.mode = 'view';
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onEdit(): void {
    this.mode = 'edit';
  }

  userInfo: ICustomer = {} as ICustomer;

  mode: 'view' | 'edit' = 'view';

  openFileInput() {
    this.fileInput.nativeElement.click();
  }

  handleFileInput(fileInput: any) {
    const reader = new FileReader();

    reader.onload = () => {
      this.userInfo.image = reader.result;
    };

    const file = fileInput.files[0];

    if (file) {
      reader.readAsDataURL(file);
    }
  }
  invalidAttributes: string[] = [];
  checkValidAttribute(attribute: string) {
    if (this.invalidAttributes.includes(attribute)) {
      return false;
    } else {
      return true;
    }
  }

  getUserInfo() {
    const token = this.authenticationService.getToken();
    this.apiService.getDetailObject('Customer', token.userID).subscribe(
      (result) => {
        this.userInfo = result;
        this.addressList = result.addressList;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  setView(view: string) {
    this.view = view;
  }

  addNewAddress() {
    this.userInfo.addressList.push('new address');
  }

  onSaveAddress(event: any, index: number) {
    // Set a variable in TypeScript to the value of the input
    this.addressList[index] = event.target.value;
    // You can now use this.inputValue in your component
  }
}
