import { Component, ViewChild, ElementRef, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { APIService } from '../../Service/API/api.service';
import { AuthenticationService } from '../../Service/Authentication/authentication.service';

@Component({
  selector: 'app-profile-manager',
  templateUrl: './profile-manager.component.html',
  styleUrl: './profile-manager.component.css'
})
export class ProfileManagerComponent implements OnInit, OnChanges {
  @ViewChild('fileInput') fileInput!: ElementRef;

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
    console.log(this.userInfo);
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

  userInfo: any = {
  };

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
      },
      (error) => {
        console.error(error);
      }
    );
  }

}
